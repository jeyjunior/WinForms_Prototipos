using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_DownloadFileAuto
{
    public partial class Principal : Form
    {
        private readonly DownloadManager downloadManager;
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
        private List<Item> ItensG1 = new List<Item>();
        private List<Item> ItensG2 = new List<Item>();

        private HttpClient httpClient;
        public Principal()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(30);

            downloadManager = new DownloadManager();
        }
        private void Principal_Load(object sender, EventArgs e)
        {

        }
        private void BindGrid1()
        {
            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var item = new Item
                {
                    Sequencia = i,
                    Nome = "Teste Grid 1 " + i,
                    ArquivosAnexo = new List<ArquivoAnexo>(),
                    ArquivoAtual = 0,
                    CaminhoArquivo = txtDiretorioDestino.Text,
                    TotalArquivos = 0,
                    TodosArquivosBaixados = false,
                    Evento = new EventHandler((e, s) => BaixarAnexosGrid1())
                };

                item.TotalArquivos = random.Next(3, Arquivos.Count + 1);

                for (int j = 0; j < item.TotalArquivos; j++)
                    item.ArquivosAnexo.Add(new ArquivoAnexo() { URL = Arquivos[j], Nome = "Arquivo_" + i + ".PDF", ArquivoBaixado = false });

                ItensG1.Add(item);
            }

            dtgArquivos1.DataSource = ItensG1.Select(c => new
            {
                Sequencia = c.Sequencia,
                Nome = c.Nome,
                Total = $"{c.ArquivoAtual}/{c.TotalArquivos}",
            }).ToList();
        }
        private void BindGrid2()
        {
            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var item = new Item
                {
                    Sequencia = i,
                    Nome = "Teste Grid 2 " + i,
                    ArquivosAnexo = new List<ArquivoAnexo>(),
                    ArquivoAtual = 0,
                    CaminhoArquivo = txtDiretorioDestino.Text,
                    TotalArquivos = 0,
                    TodosArquivosBaixados = false,
                    Evento = new EventHandler((e, s) => BaixarAnexosGrid2())
                };

                item.TotalArquivos = random.Next(3, Arquivos.Count + 1);

                for (int j = 0; j < item.TotalArquivos; j++)
                    item.ArquivosAnexo.Add(new ArquivoAnexo() { URL = Arquivos[j], Nome = "Arquivo_" + i + ".PDF", ArquivoBaixado = false });

                ItensG2.Add(item);
            }

            dtgArquivos2.DataSource = ItensG2.Select(c => new
            {
                Sequencia = c.Sequencia,
                Nome = c.Nome,
                Total = $"{c.ArquivoAtual}/{c.TotalArquivos}",
            }).ToList();
        }
        private void BaixarAnexosGrid1()
        {
            var request = new ItemRequest
            {
                Items = ItensG1,
                EventoEncerramento = (s, e) =>
                {
                    AtualizarGridCompleto(dtgArquivos1);
                }
            };

            downloadManager.AdicionarRequestDownload(request);
        }

        private void BaixarAnexosGrid2()
        {
            var request = new ItemRequest
            {
                Items = ItensG2,
                EventoEncerramento = (s, e) =>
                {
                    AtualizarGridCompleto(dtgArquivos2);
                }
            };

            downloadManager.AdicionarRequestDownload(request);
        }

        private void AtualizarGridCompleto(DataGridView grid)
        {
            if (grid.InvokeRequired)
            {
                grid.Invoke(new Action<DataGridView>(AtualizarGridCompleto), grid);
                return;
            }

            // Varre todos os itens do grid e atualiza os que não foram atualizados
            foreach (DataGridViewRow row in grid.Rows)
            {
                AtualizarLinhaGrid(row);
            }

            grid.Refresh();
        }

        private void AtualizarLinhaGrid(DataGridViewRow row) 
        {
            // row.Cells[2].Value = "Teste";
        }

        private async void btnTestar_Click(object sender, EventArgs e)
        {
            BindGrid1();
            BindGrid2();

            downloadManager.AdicionarRequestDownload(new ItemRequest() { Items = ItensG1});
            downloadManager.AdicionarRequestDownload(new ItemRequest() { Items = ItensG2});
        }
    }
}

