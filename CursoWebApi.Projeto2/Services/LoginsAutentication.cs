using CursoWebApi.Projeto2.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoWebApi.Projeto2.Services
{
    public class LoginsAutentication
    {
        public static bool Login(string login, string senha)
        {
            using ( var meuBanco = new MeuBanco())
            {
                return meuBanco.logins.Any(user => user.Login.Equals(login, StringComparison.OrdinalIgnoreCase) && user.Senha == senha);
            }

        }



    }
}