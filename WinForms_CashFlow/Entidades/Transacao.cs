using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_CashFlow.Entidades
{
    public class Transacao
    {
        public long PK_Transacao { get; set; }
        public short FK_TipoTransacao { get; set; }
        public long FK_EntidadeFinanceira { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataTransacao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string? Observacao { get; set; } 
        public int FK_Usuario { get; set; }

        public TipoTransacao TipoTransacao { get; set; }
        public DetalheInvestimento DetalheInvestimento { get; set; }
    }
}
