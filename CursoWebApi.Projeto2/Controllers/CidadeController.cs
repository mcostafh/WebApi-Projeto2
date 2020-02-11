using CursoWebApi.Projeto2.Banco;
using CursoWebApi.Projeto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace CursoWebApi.Projeto2.Controllers
{
    [Authorize(Roles ="Adm,Secretaria")]
    public class CidadeController : ApiController
    {
        // forma tradicional, poderia fazer injeção de dependência
        private MeuBanco db = new MeuBanco();

        public IQueryable<Cidade> getCidades()
        {
            return db.cidades;

        }

        public IQueryable<Cidade> getCidade(string nome)
        {
            //return db.cidades.Where( c => c.nome_cidade.Contains(nome));

            var cidades = from c in db.cidades
                          where c.nome_cidade.Contains(nome) select c;
            return cidades;
        }

        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> DeleteCidade(int id)
        {
            Cidade cidade = await db.cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            else
            {
                db.cidades.Remove(cidade);

                try
                {
                    await db.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }

                return Ok(cidade);
            }
        }

        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> FindCidade(int id)
        {
            Cidade cidade = await db.cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cidade);
            }
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCidade(int id, Cidade cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != cidade.cod_cidade)
            {
                BadRequest();
            }

            db.Entry<Cidade>(cidade).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);

        }

        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> PostCidade(Cidade cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cidades.Add(cidade);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw;
            }


            return CreatedAtRoute("DeafultApi", new { id = cidade.cod_cidade }, cidade);

        }


    }
}