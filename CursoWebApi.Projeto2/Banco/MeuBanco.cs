using CursoWebApi.Projeto2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CursoWebApi.Projeto2.Banco
{
    public class MeuBanco : DbContext
    {
        public MeuBanco() : base("BancoDados")
        {

        }

        public DbSet<Cidade> cidades { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<LoginsSistema> logins { get; set; }
    }
}