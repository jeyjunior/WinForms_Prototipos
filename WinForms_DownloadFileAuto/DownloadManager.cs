using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinForms_DownloadFileAuto
{
    public class DownloadManager
    {
        private readonly ConcurrentQueue<ItemRequest> _requestQueue;
        private readonly List<Thread> _activeThreads;
        private readonly Semaphore _threadSemaphore;
        private readonly HttpClient _httpClient;
        private readonly object _lockObject = new object();
        private bool _isProcessing;
        private CancellationTokenSource _globalCts;
        private readonly Dictionary<Guid, int> _requestProgress;

        public DownloadManager()
        {
            _requestQueue = new ConcurrentQueue<ItemRequest>();
            _activeThreads = new List<Thread>();
            _threadSemaphore = new Semaphore(5, 5);
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(3);
            _globalCts = new CancellationTokenSource();
            _isProcessing = false;
            _requestProgress = new Dictionary<Guid, int>();
        }

        public void AdicionarRequestDownload(ItemRequest request)
        {
            if (request?.Items == null || !request.Items.Any())
                return;

            foreach (var anexo in request.Items)
                anexo.RequestId = request.RequestId;

            _requestQueue.Enqueue(request);
            IniciarProcessamento();
        }
        private void IniciarProcessamento()
        {
            lock (_lockObject)
            {
                if (_isProcessing)
                    return;

                _isProcessing = true;
            }

            Thread processThread = new Thread(ProcessarFilaRequests);
            processThread.IsBackground = true;
            processThread.Start();
        }

        private void ProcessarFilaRequests()
        {
            try
            {
                while (_requestQueue.TryDequeue(out ItemRequest request))
                {
                    // Inicia o rastreamento do progresso desta request
                    _requestProgress[request.RequestId] = 0;

                    foreach (var anexo in request.Items)
                    {
                        _threadSemaphore.WaitOne();

                        Thread downloadThread = new Thread(() =>
                        {
                            try
                            {
                                ProcessarAnexo(anexo, request);
                            }
                            finally
                            {
                                _threadSemaphore.Release();

                                // Atualiza progresso e verifica se finalizou
                                lock (_requestProgress)
                                {
                                    _requestProgress[request.RequestId]++;
                                    if (_requestProgress[request.RequestId] >= request.Items.Count)
                                    {
                                        // Todos os anexos desta request foram processados
                                        DispararEventoEncerramento(request);
                                        _requestProgress.Remove(request.RequestId);
                                    }
                                }
                            }
                        });

                        downloadThread.IsBackground = true;
                        _activeThreads.Add(downloadThread);
                        downloadThread.Start();
                    }
                }
            }
            finally
            {
                lock (_lockObject)
                    _isProcessing = false;
            }
        }

        private void ProcessarAnexo(Item anexo, ItemRequest request)
        {
            try
            {
                if (anexo.ArquivosAnexo?.Count <= 0)
                {
                    anexo.TodosArquivosBaixados = true;
                    DispararEventoAtualizacao(anexo);
                    return;
                }

                ValidarExistenciaArquivos(anexo);
                DispararEventoAtualizacao(anexo);

                if (!anexo.TodosArquivosBaixados)
                {
                    bool todosBaixados = true;

                    foreach (var arquivo in anexo.ArquivosAnexo.Where(a => a != null && !a.ArquivoBaixado))
                    {
                        bool baixado = BaixarArquivo(arquivo, anexo);
                        if (!baixado)
                            todosBaixados = false;

                        DispararEventoAtualizacao(anexo);
                    }

                    anexo.TodosArquivosBaixados = todosBaixados;
                    DispararEventoAtualizacao(anexo);
                }
            }
            catch (Exception ex)
            {
                DispararEventoAtualizacao(anexo);
            }
        }

        private bool BaixarArquivo(ArquivoAnexo arquivo, Item item)
        {
            try
            {
                string nomeArquivoNormalizado = arquivo.Nome.Normalize(NormalizationForm.FormC);
                string nomeArquivoValido = string.Concat(nomeArquivoNormalizado.Split(Path.GetInvalidFileNameChars()));
                string caminhoCompleto = Path.Combine(item.CaminhoArquivo, nomeArquivoValido);

                if (!Directory.Exists(item.CaminhoArquivo))
                    Directory.CreateDirectory(item.CaminhoArquivo);

                if (!File.Exists(caminhoCompleto))
                {
                    var response = Task.Run(() =>
                        _httpClient.GetAsync(arquivo.URL, HttpCompletionOption.ResponseHeadersRead, _globalCts.Token)
                    ).Result;

                    response.EnsureSuccessStatusCode();

                    using (var fileStream = new FileStream(caminhoCompleto, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    using (var httpStream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result)
                    {
                        httpStream.CopyTo(fileStream);
                    }
                }

                if (File.Exists(caminhoCompleto))
                {
                    arquivo.ArquivoBaixado = true;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void ValidarExistenciaArquivos(Item item)
        {
            try
            {
                if (item == null) 
                    return;

                if (!Directory.Exists(item.CaminhoArquivo) || item.ArquivosAnexo == null)
                {
                    item.TodosArquivosBaixados = false;
                    return;
                }

                var listaArquivosBaixado = Directory.GetFiles(item.CaminhoArquivo, "*.*")
                    .Select(Path.GetFileName)
                    .Select(f => f.ToUpperInvariant())
                    .ToList();

                item.TodosArquivosBaixados = true;

                foreach (var arquivo in item.ArquivosAnexo)
                {
                    string nomeArquivoNormalizado = arquivo.Nome.Normalize(NormalizationForm.FormC);
                    string nomeArquivoValido = string.Concat(nomeArquivoNormalizado.Split(Path.GetInvalidFileNameChars()));
                    nomeArquivoValido = nomeArquivoValido.ToUpper();

                    if (!listaArquivosBaixado.Contains(nomeArquivoValido))
                    {
                        item.TodosArquivosBaixados = false;
                        break;
                    }
                    else
                    {
                        arquivo.ArquivoBaixado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DispararEventoAtualizacao(Item item)
        {
            try
            {
                item.Evento?.Invoke(item, EventArgs.Empty);
            }
            catch
            {
                // Ignora erros de evento
            }
        }

        private void DispararEventoEncerramento(ItemRequest request)
        {
            try
            {
                request.EventoEncerramento?.Invoke(request, EventArgs.Empty);
            }
            catch
            {
            }
        }

        public void CancelarDownloads()
        {
            _globalCts.Cancel();
        }

        public void Dispose()
        {
            _globalCts?.Cancel();
            _httpClient?.Dispose();
            _globalCts?.Dispose();
        }

    }
}

public class Item
{
    public Guid RequestId { get; set; }
    public int Sequencia { get; set; }
    public string Nome { get; set; }
    public int TotalArquivos { get; set; }
    public int ArquivoAtual { get; set; }
    public bool TodosArquivosBaixados { get; set; }
    public string CaminhoArquivo { get; set; }
    public EventHandler Evento { get; set; }
    public List<ArquivoAnexo> ArquivosAnexo { get; set; }
}

public class ItemRequest
{   
    public ItemRequest()
    {
        RequestId = Guid.NewGuid();
    }

    public Guid RequestId { get; private set; }

    public List<Item> Items { get; set; }
    public EventHandler EventoEncerramento { get; set; }
}

public class ArquivoAnexo
{
    public string Nome { get; set; }
    public string URL { get; set; }
    public bool ArquivoBaixado { get; set; }

}