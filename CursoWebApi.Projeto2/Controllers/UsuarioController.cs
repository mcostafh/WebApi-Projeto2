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

    [Authorize(Roles ="Adm")]
    public class UsuarioController : ApiController
    {
        // forma tradicional, poderia fazer injeção de dependência
        private MeuBanco db = new MeuBanco();

        public IQueryable<Usuario> getUsuario()
        {
            return db.usuarios;

        }

        public IQueryable<Usuario> getUsuario(string nome)
        {
            //return db.cidades.Where( c => c.nome_cidade.Contains(nome));

            var usuarios = from c in db.usuarios
                          where c.nome.Contains(nome) select c;
            return usuarios;
        }

        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                db.usuarios.Remove(usuario);

                try
                {
                    await db.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }

                return Ok(usuario);
            }
        }

        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(int id)
        {
            Usuario usuario = await db.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuario);
            }
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != usuario.Cod_cliente)
            {
                BadRequest();
            }

            db.Entry<Usuario>(usuario).State = System.Data.Entity.EntityState.Modified;

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

        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuarios.Add(usuario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw;
            }


            return CreatedAtRoute("DeafultApi", new { id = usuario.Cod_cliente }, usuario);

        }


    }
}