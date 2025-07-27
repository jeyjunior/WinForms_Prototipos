using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WinForms_CashFlow.Entidades;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WinForms_CashFlow
{
    public partial class Principal : Form
    {
        string conexao = @"Server=(localdb)\MSSQLLocalDB;Database=CashFlow;Integrated Security=True;";
        public Principal()
        {
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            CarregarDropDowns();
            Bind();
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            try
            {
                // Cria a conexão com o banco de dados
                using (var db = new SqlConnection(conexao))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT  Transacao.*,");
                    sql.AppendLine("        TipoTransacao.*,");
                    sql.AppendLine("        DetalheInvestimento.*,");
                    sql.AppendLine("        Ativo.*");
                    sql.AppendLine("FROM    Transacao");
                    sql.AppendLine("INNER   JOIN    TipoTransacao");
                    sql.AppendLine("ON      TipoTransacao.PK_TipoTransacao = Transacao.FK_TipoTransacao");
                    sql.AppendLine("LEFT    JOIN    DetalheInvestimento");
                    sql.AppendLine("ON      DetalheInvestimento.FK_Transacao = Transacao.PK_Transacao");
                    sql.AppendLine("LEFT    JOIN    Ativo");
                    sql.AppendLine("ON      ATIVO.PK_Ativo = DetalheInvestimento.FK_Ativo");

                    string query = sql.ToString();

                    var transacoes = db.Query<Transacao, TipoTransacao, DetalheInvestimento, Ativo, Transacao>(
                        query,
                        (transacao, tipoTransacao, detalheInvestimento, ativo) =>
                        {
                            transacao.TipoTransacao = tipoTransacao;

                            if (tipoTransacao != null)
                                transacao.TipoTransacao = tipoTransacao;

                            if (detalheInvestimento != null)
                            {
                                transacao.DetalheInvestimento = detalheInvestimento;

                                if (ativo != null)
                                    transacao.DetalheInvestimento.Ativo = ativo;
                            }
                            return transacao;
                        },
                        splitOn: "PK_TipoTransacao, PK_TipoTransacao, PK_DetalheInvestimento, PK_Ativo"
                    ).ToList();

                    dtgTransacao.DataSource = transacoes.Select(c => new
                    {
                        PK_Transacao = c.PK_Transacao,
                        Tipo = c.TipoTransacao != null ? c.TipoTransacao.Nome : "",
                        Ativo = c.DetalheInvestimento != null ? (c.DetalheInvestimento.Ativo != null ? c.DetalheInvestimento.Ativo.Codigo : "") : "",
                        QtdCotas = c.DetalheInvestimento != null ? c.DetalheInvestimento.QuantidadeCotas.ToString("N2") : "",
                        ValorUnitario = c.DetalheInvestimento != null ? c.DetalheInvestimento.ValorUnitario.ToString("N2") : "",
                        Imposto = c.DetalheInvestimento != null ? (c.DetalheInvestimento.Imposto != null ? c.DetalheInvestimento.Imposto.Value.ToString("N2") : "") : "",
                        Outros = c.DetalheInvestimento != null ? (c.DetalheInvestimento.OutrosCustos != null ? c.DetalheInvestimento.OutrosCustos.Value.ToString("N2") : "") : "",
                        Total = c.Valor.ToString("N2")
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void CarregarDropDowns()
        {
            CarregarTipoTransacao();
            CarregarEntidadeFinanceira();
            CarregarAtivo();
        }

        private void CarregarTipoTransacao()
        {
            try
            {
                using (var db = new SqlConnection(conexao))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT  TipoTransacao.*");
                    sql.AppendLine("FROM    TipoTransacao");

                    string query = sql.ToString();

                    var transacoes = db.Query<TipoTransacao>(query).ToList();

                    cboTipoTransacao.ValueMember = "PK_TipoTransacao";
                    cboTipoTransacao.DisplayMember = "Nome";
                    cboTipoTransacao.DataSource = transacoes;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void CarregarEntidadeFinanceira()
        {
            try
            {
                using (var db = new SqlConnection(conexao))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT  EntidadeFinanceira.*");
                    sql.AppendLine("FROM    EntidadeFinanceira");

                    string query = sql.ToString();

                    var entidadeFinanceira = db.Query<EntidadeFinanceira>(query).ToList();

                    cboEntidadeFinanceira.ValueMember = "PK_EntidadeFinanceira";
                    cboEntidadeFinanceira.DisplayMember = "Nome";
                    cboEntidadeFinanceira.DataSource = entidadeFinanceira;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void CarregarAtivo()
        {
            try
            {
                using (var db = new SqlConnection(conexao))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT  Ativo.*");
                    sql.AppendLine("FROM    Ativo");

                    string query = sql.ToString();

                    var ativo = db.Query<Ativo>(query).ToList();

                    cboAtivo.ValueMember = "PK_Ativo";
                    cboAtivo.DisplayMember = "Nome";
                    cboAtivo.DataSource = ativo;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SqlConnection(conexao))
                {
                    StringBuilder insertTransacao = new StringBuilder();
                    StringBuilder insertDetalhe = new StringBuilder();

                    insertTransacao.AppendLine("INSERT INTO Transacao (FK_TipoTransacao, FK_EntidadeFinanceira, Valor, DataTransacao, DataVencimento, Observacao, FK_Usuario)\n");
                    insertTransacao.AppendLine("VALUES      (@FK_TipoTransacao, @FK_EntidadeFinanceira, @Valor, @DataTransacao, @DataVencimento, @Observacao, @FK_Usuario)");

                    insertDetalhe.AppendLine("INSERT INTO DetalheInvestimento (FK_Transacao, FK_Ativo, QuantidadeCotas, ValorUnitario, Imposto, OutrosCustos)\n");
                    insertDetalhe.AppendLine("VALUES      (@FK_Transacao, @FK_Ativo, @QuantidadeCotas, @ValorUnitario, @Imposto, @OutrosCustos)");

                    var transacao = new Transacao
                    {
                        FK_TipoTransacao = Convert.ToInt16(cboTipoTransacao.SelectedValue),
                        FK_EntidadeFinanceira = Convert.ToInt64(cboEntidadeFinanceira.SelectedValue),
                        Valor = nTotal.Value,
                        DataTransacao = dtpTransacao.Checked ? Convert.ToDateTime(dtpTransacao.Text) : DateTime.Now,
                        DataVencimento = dtpVencimento.Checked ? Convert.ToDateTime(dtpVencimento.Text) : null,
                        FK_Usuario = 1,
                        Observacao = ""
                    };

                    var retTransacao = db.Execute(insertTransacao.ToString(), transacao);
                    long pk_Transacao = 0;

                    if (retTransacao > 0)
                    {
                        var ret = db.Query<Transacao>("SELECT TOP 1 * FROM Transacao ORDER BY PK_Transacao DESC");

                        if (ret != null)
                        {
                            pk_Transacao = ret.FirstOrDefault().PK_Transacao;
                        }
                    }

                    var detalheInvestimento = new DetalheInvestimento
                    {
                        FK_Transacao = pk_Transacao,
                        FK_Ativo = Convert.ToInt64(cboAtivo.SelectedValue),
                        QuantidadeCotas = nQuantidadeCotas.Value,
                        ValorUnitario = nValorUnitario.Value,
                        Imposto = nImposto.Value,
                        OutrosCustos = nOutros.Value
                    };

                    var fk_DetalheInvestimento = db.Execute(insertDetalhe.ToString(), detalheInvestimento);

                    Bind();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void CalcularTotal_ValueChanged(object sender, EventArgs e)
        {
            decimal qtd = nQuantidadeCotas.Value;
            decimal unitario = nValorUnitario.Value;
            decimal imposto = nImposto.Value;
            decimal outros = nOutros.Value;

            var total = (qtd * unitario) + (imposto + outros);  

            nTotal.Value = total;
        }
    }
}

/*
INSERT INTO "Transacao" ("FK_TipoTransacao", "FK_EntidadeFinanceira", "Valor", "DataTransacao", "DataVencimento", "Observacao", "FK_Usuario")
VALUES	(2, 5, 38.97, DATEADD(DAY, -15, GETDATE()), NULL, 'Compra PETR4', 1), --Compra
		(2, 4, 76.40, DATEADD(DAY, -35, GETDATE()), NULL, 'Compra PETR4', 1),   --Compra
		(1, 2, 28.00, DATEADD(DAY, -3, GETDATE()), NULL, 'Compra PETR4', 1),    --Venda
		(1, 3, 40.65, DATEADD(DAY, -5, GETDATE()), NULL, 'Compra PETR4', 1); --Venda

INSERT INTO "DetalheInvestimento" ("FK_Transacao", "FK_Ativo", "QuantidadeCotas", "ValorUnitario", "Imposto", "OutrosCustos")
VALUES
		-- Compras PETR4
		(10016, 2, 3, 12.99, 0, 0), -- Simulando um valor X na primeira compra R$ 10,00
		(10017, 2, 8, 9.55, 0, 0),      -- Simulando um valor Y na segunda compra R$ 5,00
		-- Vendas PETR4
		(10018, 2, 2, 14.00, 0, 0), -- Simulando um valor Y na segunda venda R$ 11,00
		(10019, 2, 3, 13.55, 0, 0); --Simulando um valor X na primeira venda R$ 20,00

*/