using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_CashFlow.Entidades
{
    public class Ativo
    {
        public long PK_Ativo { get; set; }
        public string Codigo { get; set; }
        public string? Nome { get; set; }
        public int FK_TipoInvestimento { get; set; }
        public int FK_Usuario { get; set; }
        public bool AtivoStatus { get; set; }
    }
}
