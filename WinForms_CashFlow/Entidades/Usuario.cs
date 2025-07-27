using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_CashFlow.Entidades
{
    public class Usuario
    {
        public int PK_Usuario { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; } 
        public string? LoginApi { get; set; }
        public string? Senha { get; set; } 
        public string? Salt { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
