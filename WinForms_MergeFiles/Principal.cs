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

        }
        private void btnMerge_Click(object sender, EventArgs e)
        {
            HabilitarBotoes(eOperacao.Merge);

            try
            {

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
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }
        #endregion

        #region Metodos
        // HELPERS
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
    }
}
