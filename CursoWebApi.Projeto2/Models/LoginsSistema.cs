using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoWebApi.Projeto2.Models
{
    public class LoginsSistema
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha {get; set; }
        public string Role { get; set; }
    }
}