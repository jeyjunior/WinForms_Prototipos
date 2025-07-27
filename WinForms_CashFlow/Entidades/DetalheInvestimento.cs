using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_CashFlow.Entidades
{
    public class DetalheInvestimento
    {
        public long PK_DetalheInvestimento { get; set; }
        public long FK_Transacao { get; set; }
        public long FK_Ativo { get; set; }
        public decimal QuantidadeCotas { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal? Imposto { get; set; } 
        public decimal? OutrosCustos { get; set; } 

        public Ativo Ativo { get; set; }
    }
}
