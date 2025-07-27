using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_CashFlow.Entidades
{
    public class Categoria
    {
        public int PK_Categoria { get; set; }
        public string Nome { get; set; }
        public int FK_Usuario { get; set; }
    }
}
