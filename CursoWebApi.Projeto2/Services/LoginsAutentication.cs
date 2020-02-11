using CursoWebApi.Projeto2.Banco;
using CursoWebApi.Projeto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoWebApi.Projeto2.Services
{
    public class LoginsAutentication
    {
        public static LoginsSistema Login(string login, string senha)
        {
            /*using ( var meuBanco = new MeuBanco())
            
            {
                return meuBanco.logins.Any(user => user.Login.Equals(login, StringComparison.OrdinalIgnoreCase) && user.Senha == senha);
            }*/

            using (MeuBanco db = new MeuBanco())
            {
                return db.logins.FirstOrDefault(user => user.Login.Equals(login, StringComparison.OrdinalIgnoreCase) && user.Senha == senha);
            }
            

        }



    }
}