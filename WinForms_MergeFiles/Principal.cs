using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_MergeFiles
{
    public partial class Principal : Form
    {
        #region Propriedades
        private string _caminhoDestino = "";
        private List<string> _arquivosSelecionados = new List<string>();

        enum eOperacao
        {
            Visualizar = 0,
            Merge = 1,
        }
        #endregion

        #region Construtor
        public Principal()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void Principal_Load(object sender, EventArgs e)
        {
            LimparTela();
        }

        // BOTÕES
        private void btnDiretorioDestino_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Selecione a pasta onde os arquivos serão salvos";
                    folderDialog.ShowNewFolderButton = true;
                    folderDialog.RootFolder = Environment.SpecialFolder.Desktop;

                    if (!string.IsNullOrEmpty(txtDiretorioDestino.Text) && System.IO.Directory.Exists(txtDiretorioDestino.Text))
                        folderDialog.SelectedPath = txtDiretorioDestino.Text;

                    DialogResult result = folderDialog.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                        _caminhoDestino = folderDialog.SelectedPath;

                    txtDiretorioDestino.Text = _caminhoDestino;
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
            }
            finally
            {
                HabilitarBotoes(eOperacao.Visualizar);
            }
        }
        private void btnSelecionarArquivos_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Selecione os arquivos PDF";
                    openFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf";
                    openFileDialog.Multiselect = true;
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.CheckPathExists = true;

                    DialogResult result = openFileDialog.ShowDialog();

                    if (result == DialogResult.OK && openFileDialog.FileNames.Length > 0)
                    {
                        txtArquivos.Text = "";

                        _arquivosSelecionados = new List<string>();

                        foreach (string arquivo in openFileDialog.FileNames)
                        {
                            _arquivosSelecionados.Add(arquivo);
                            txtArquivos.Text += arquivo + Environment.NewLine;
                        }

                        lblStatusArquivos.Text = $"{openFileDialog.FileNames.Length} arquivo(s) selecionado(s)";
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
            }
            finally
            {
                HabilitarBotoes(eOperacao.Visualizar);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarBotoes(eOperacao.Visualizar);
            AdicionarLog("Operação cancelada pelo usuário.");
            progress.Value = 0;
        }
        private void btnMerge_Click(object sender, EventArgs e)
        {
            HabilitarBotoes(eOperacao.Merge);

            try
            {
                txtLog.Text = "";

                if (_arquivosSelecionados.Count == 0)
                {
                    ExibirMensagem("Selecione pelo menos um arquivo PDF.");
                    return;
                }

                if (string.IsNullOrEmpty(_caminhoDestino))
                {
                    ExibirMensagem("Selecione um diretório de destino.");
                    return;
                }

                string nomeArquivoSaida = GerarNomeArquivoSaida();

                AdicionarLog("Iniciando processo de merge...");
                AdicionarLog($"Arquivos a serem processados: {_arquivosSelecionados.Count}");
                AdicionarLog($"Destino: {_caminhoDestino}");

                Task.Run(() =>
                {
                    bool sucesso = FazerMergePdfs(_arquivosSelecionados, _caminhoDestino, nomeArquivoSaida);

                    this.Invoke(new Action(() =>
                    {
                        if (sucesso)
                        {
                            AdicionarLog("Processo concluído com sucesso!");
                            ExibirMensagem($"Merge concluído! Arquivo salvo como: {nomeArquivoSaida}");
                        }
                        else
                        {
                            AdicionarLog("Processo concluído com erros.");
                            ExibirMensagem("Ocorreram erros durante o merge. Verifique o log para detalhes.");
                        }

                        HabilitarBotoes(eOperacao.Visualizar);
                        progress.Value = 0;
                    }));
                });
            }
            catch (Exception ex)
            {
                AdicionarLog($"Erro: {ex.Message}");
                ExibirMensagem(ex.Message);
                HabilitarBotoes(eOperacao.Visualizar);
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }
        #endregion

        #region Metodos Helpers
        private void LimparTela()
        {
            txtDiretorioDestino.Text = "";
            txtArquivos.Text = "";
            txtLog.Text = "";

            lblStatusArquivos.Text = "";
            lblStatusLog.Text = "";

            progress.Value = 0;
            progress.Minimum = 0;
            progress.Maximum = 100;

            _caminhoDestino = "";
            _arquivosSelecionados = new List<string>();

            HabilitarBotoes(eOperacao.Visualizar);
        }
        private void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK);
        }
        private void HabilitarBotoes(eOperacao operacao)
        {
            switch (operacao)
            {
                case eOperacao.Visualizar:
                    btnSelecionarArquivos.Enabled = true;
                    btnDiretorioDestino.Enabled = true;
                    btnLimpar.Enabled = true;
                    btnMerge.Enabled = (_caminhoDestino.Length > 0 && _arquivosSelecionados.Count > 0);
                    
                    btnCancelar.Enabled = false;
                    break;
                case eOperacao.Merge:

                    btnSelecionarArquivos.Enabled = false;
                    btnDiretorioDestino.Enabled = false;
                    btnLimpar.Enabled = false;
                    btnMerge.Enabled = false;

                    btnCancelar.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Merge
        private bool FazerMergePdfs(List<string> arquivos, string caminhoDestino, string nomeArquivoSaida = "arquivo_unificado.pdf")
        {
            try
            {
                if (arquivos == null || arquivos.Count == 0)
                {
                    ExibirMensagem("Nenhum arquivo selecionado para merge.");
                    return false;
                }

                if (!System.IO.Directory.Exists(caminhoDestino))
                {
                    ExibirMensagem("Diretório de destino não existe.");
                    return false;
                }

                string caminhoCompleto = System.IO.Path.Combine(caminhoDestino, nomeArquivoSaida);

                if (System.IO.File.Exists(caminhoCompleto))
                {
                    DialogResult resultado = MessageBox.Show(
                        "O arquivo de saída já existe. Deseja substituir?",
                        "Arquivo existente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.No)
                    {
                        return false;
                    }
                }

                using (System.IO.FileStream fs = new System.IO.FileStream(caminhoCompleto, System.IO.FileMode.Create))
                {
                    using (iTextSharp.text.Document doc = new iTextSharp.text.Document())
                    {
                        using (iTextSharp.text.pdf.PdfCopy copy = new iTextSharp.text.pdf.PdfCopy(doc, fs))
                        {
                            doc.Open();

                            for (int i = 0; i < arquivos.Count; i++)
                            {
                                string arquivo = arquivos[i];

                                if (!System.IO.File.Exists(arquivo))
                                {
                                    AdicionarLog($"Arquivo não encontrado: {arquivo}");
                                    continue;
                                }

                                try
                                {
                                    using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(arquivo))
                                    {
                                        int numeroPaginas = reader.NumberOfPages;

                                        for (int pagina = 1; pagina <= numeroPaginas; pagina++)
                                        {
                                            iTextSharp.text.pdf.PdfImportedPage importedPage = copy.GetImportedPage(reader, pagina);
                                            copy.AddPage(importedPage);
                                        }

                                        reader.Close();

                                        AdicionarLog($"Processado: {System.IO.Path.GetFileName(arquivo)} ({numeroPaginas} páginas)");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AdicionarLog($"Erro ao processar {System.IO.Path.GetFileName(arquivo)}: {ex.Message}");
                                    continue;
                                }

                                int progresso = (int)((i + 1) / (double)arquivos.Count * 100);
                                AtualizarProgresso(progresso);
                            }

                            doc.Close();
                        }
                    }
                }

                AdicionarLog($"Merge concluído! Arquivo salvo em: {caminhoCompleto}");
                return true;
            }
            catch (Exception ex)
            {
                AdicionarLog($"Erro durante o merge: {ex.Message}");
                return false;
            }
        }

        private void AdicionarLog(string mensagem)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(AdicionarLog), mensagem);
            }
            else
            {
                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                txtLog.AppendText($"[{timestamp}] {mensagem}{Environment.NewLine}");
                txtLog.ScrollToCaret();

                lblStatusLog.Text = $"Última ação: {mensagem}";
            }
        }

        private void AtualizarProgresso(int valor)
        {
            if (progress.InvokeRequired)
            {
                progress.Invoke(new Action<int>(AtualizarProgresso), valor);
            }
            else
            {
                progress.Value = Math.Min(Math.Max(valor, progress.Minimum), progress.Maximum);
            }
        }

        private string GerarNomeArquivoSaida()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"merged_{timestamp}.pdf";
        }
        #endregion
    }
}
