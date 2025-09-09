using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace WinForms_DownloadFileAuto
{
    public partial class Principal : Form
    {
        private List<string> Arquivos = new List<string>()
        {
            "https://archivepublicdomain.com/files/2025/06/A-ARTE-DA-GUERRA.pdf",
            "https://multimidia.gazetadopovo.com.br/media/info/2021/202110/bichos/revolucao-dos-bichos.pdf",
            "https://livraria-camara-leg.usrfiles.com/ugd/5ca0e9_77426ca451ec4f60b14af67f925f038e.pdf",
            "https://eniopadilha-com-br.usrfiles.com/ugd/5ca0e9_25f5954b7b7a4a76892d3650ec0cd36c.pdf",
            "https://www.ebooksbrasil.org/adobeebook/alicep.pdf",
            "https://archivepublicdomain.com/files/2025/02/metamorfose.pdf",
            "https://archivepublicdomain.com/files/2025/02/O-Alienista.pdf",
            "https://camara-leg-br.usrfiles.com/ugd/5ca0e9_4bd76b96516a40fba87370e6bcec72f8.pdf",
            "https://www.baixelivros.com.br/ciencias-humanas-e-sociais/filosofia/o-banquete-platao",
            "https://5ca0e999-de9a-47e0-9b77-7e3eeab0592c.usrfiles.com/ugd/5ca0e9_4f0243f83ea945ed98bfa7570d3b743c.pdf",
        };
        private List<Item> Itens = new List<Item>();
        private HttpClient httpClient;
        public Principal()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(30);
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var item = new Item
                {
                    Sequencia = i,
                    Nome = "Teste " + i,
                    Arquivos = new List<string>(),
                    ArquivoAtual = 0,
                };

                item.TotalArquivos = random.Next(3, Arquivos.Count + 1);

                for (int j = 0; j < item.TotalArquivos; j++)
                    item.Arquivos.Add(Arquivos[j]);

                Itens.Add(item);
            }

            Bind();
        }

        private void Bind()
        {
            dtgArquivos.DataSource = Itens.Select(c => new
            {
                Sequencia = c.Sequencia,
                Nome = c.Nome,
                Total = $"{c.ArquivoAtual}/{c.TotalArquivos}",
                Status = c.Status
            }).ToList();
        }

        private async void btnTestar_Click(object sender, EventArgs e)
        {
            string diretorio = txtDiretorioDestino.Text;

            if (string.IsNullOrWhiteSpace(diretorio))
            {
                MessageBox.Show("Por favor, informe o diretório de destino.");
                return;
            }

            if (!Directory.Exists(diretorio))
            {
                MessageBox.Show("Diretório de destino não existe.");
                return;
            }

            btnTestar.Enabled = false;
            btnTestar.Text = "Baixando...";

            try
            {
                await ProcessarDownloads(diretorio);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante o download: {ex.Message}");
            }
            finally
            {
                btnTestar.Enabled = true;
                btnTestar.Text = "Download";
            }
        }

        private async Task ProcessarDownloads(string diretorioBase)
        {
            foreach (var item in Itens)
            {
                item.Status = "Iniciando...";
                Bind();

                string diretorioItem = Path.Combine(diretorioBase, item.Nome);

                if (!Directory.Exists(diretorioItem))
                {
                    Directory.CreateDirectory(diretorioItem);
                }

                for (int i = 0; i < item.Arquivos.Count; i++)
                {
                    string url = item.Arquivos[i];
                    string nomeArquivo = ObterNomeArquivoFromUrl(url);
                    string caminhoCompleto = Path.Combine(diretorioItem, nomeArquivo);

                    item.Status = $"Baixando {i + 1}/{item.TotalArquivos}";
                    Bind();

                    try
                    {
                        await BaixarArquivo(url, caminhoCompleto);
                        item.ArquivoAtual = i + 1;
                        item.Status = "Sucesso";
                    }
                    catch (Exception ex)
                    {
                        item.Status = $"Erro: {ex.Message}";
                        break; 
                    }

                    Bind();
                    await Task.Delay(100); 
                }

                Bind();
            }
        }

        private async Task BaixarArquivo(string url, string caminhoDestino)
        {
            try
            {
                using (var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(caminhoDestino, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao baixar {url}: {ex.Message}");
            }
        }

        private string ObterNomeArquivoFromUrl(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                return Path.GetFileName(uri.LocalPath);
            }
            catch
            {
                return $"arquivo_{DateTime.Now:yyyyMMddHHmmssfff}.download";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            httpClient?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

public class Item
{
    public int Sequencia { get; set; }
    public string Nome { get; set; }
    public int TotalArquivos { get; set; }
    public int ArquivoAtual { get; set; }
    public string Status { get; set; } = "Pendente";
    public List<string> Arquivos { get; set; }
}