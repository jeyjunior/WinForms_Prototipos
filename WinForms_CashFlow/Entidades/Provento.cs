using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_CashFlow.Entidades
{
    public class Provento
    {
        public long PK_Provento { get; set; }
        public long FK_Transacao { get; set; }
        public long FK_Ativo { get; set; }
        public decimal? QuantidadeCotasBase { get; set; } 
        public decimal? ValorPorCota { get; set; } 
        public decimal? Imposto { get; set; } 
        public string? Descricao { get; set; }
    }
}
