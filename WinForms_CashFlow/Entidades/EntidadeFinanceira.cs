using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_CashFlow.Entidades
{
    public class EntidadeFinanceira
    {
        public long PK_EntidadeFinanceira { get; set; }
        public short FK_TipoEntidadeFinanceira { get; set; }
        public int? FK_Categoria { get; set; } // Nullable
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public int FK_Usuario { get; set; }
        public bool Ativo { get; set; }
    }
}
