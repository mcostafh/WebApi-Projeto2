using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TesteWebApi.Services;
using TesteWebApi.ViewModels;

namespace TesteWebApi.Controllers
{
    public class UsuarioController : Controller
    {
        static IEnumerable<Cidade> cidade = null;


        private async System.Threading.Tasks.Task<IEnumerable<Cidade>> GetCidadesAsync()
        {
            IEnumerable<Cidade> cidades = null;

            var apiRest = new ApiClientRest(Session, "http://localhost", "56791");
            HttpResponseMessage resposta = await apiRest.Get("/Api/Cidades");

            if (resposta.IsSuccessStatusCode)
            {
                var conteudo = resposta.Content.ReadAsStringAsync().Result;
                cidades = JsonConvert.DeserializeObject<Cidade[]>(conteudo);


            }

            return cidades;


        }

        // GET: Usuario / Create
        public async System.Threading.Tasks.Task<ActionResult> Create()
        {
            cidade = await GetCidadesAsync();
            if (cidade != null)
            {

                ViewBag.cod_cidade = new SelectList(
                    cidade,
                    "cod_cidade",
                    "nome_cidade"
                    );
            }
           
            return View();
        }

        // GET: Usuario /Edit/5
        public async System.Threading.Tasks.Task<ActionResult> Edit( int id)
        {
            Usuario usuario = null;
            cidade = await GetCidadesAsync();

            var apiRest = new ApiClientRest(Session, "http://localhost", "56791");
            HttpResponseMessage resposta = await apiRest.Get("/Api/Usuario/"+id);


            if (resposta.IsSuccessStatusCode)
            {
                var conteudo = resposta.Content.ReadAsStringAsync().Result;
                usuario = JsonConvert.DeserializeObject<Usuario>(conteudo);

            }


            ViewBag.cod_cidade = new SelectList(
                        cidade,
                        "cod_cidade",
                        "nome_cidade",
                        usuario.cod_cidade
                        );

            return View(usuario);
        }


        // POST: usuario/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create( Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.cod_cidade = new SelectList(
                        cidade,
                        "cod_cidade",
                        "nome_cidade",
                        usuario.cod_cidade
                        );
                    return View(usuario);
                }

                var apiRest = new ApiClientRest(Session, "http://localhost", "56791");
                HttpResponseMessage resposta = await apiRest.Get("/Api/Usuario" );
                await apiRest.client.PostAsJsonAsync("/Api/Usuario", usuario);
                return RedirectToAction("Index");

            }
            catch {
                return View();
            }
            
        }


        // GET: Usuario
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            
            IEnumerable<Usuario> usuarios = null;


            var apiRest = new ApiClientRest(  Session,  "http://localhost","56791");

            HttpResponseMessage resposta = await apiRest.Get("/Api/Usuario");

            if (resposta.IsSuccessStatusCode)
            {
                var conteudo = resposta.Content.ReadAsStringAsync().Result;
                usuarios = JsonConvert.DeserializeObject<Usuario[]>(conteudo);
            }
                                
            return View(usuarios);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit(int id, Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.cod_cidade = new SelectList(
                        cidade,
                        "cod_cidade",
                        "nome_cidade",
                        usuario.cod_cidade
                        );
                    return View(usuario);
                }

                id = usuario.Cod_cliente;

                var apiRest = new ApiClientRest(Session, "http://localhost", "56791");
                HttpResponseMessage resposta = await apiRest.Put("/Api/Usuario/" + id, usuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }



        }

        // Get: Usuario/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> Delete ( int id)
        {
            Usuario usuario=null;
            cidade = await GetCidadesAsync();

            var apiRest = new ApiClientRest(Session, "http://localhost", "56791");
            HttpResponseMessage resposta = await apiRest.Get("/Api/Usuario/" + id);
            if (resposta.IsSuccessStatusCode)
            {
                var conteudo = resposta.Content.ReadAsStringAsync().Result;
                usuario = JsonConvert.DeserializeObject<Usuario>(conteudo);
            }

            ViewBag.cod_cidade = new SelectList(
                cidade,
                "cod_cidade",
                "nome_cidade",
                usuario.cod_cidade
                );


            return View(usuario);
        }


        // Post: Usuario/Delete/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Delete ( int id, Usuario usuario)
        {
            try
            {
                var apiRest = new ApiClientRest(Session, "http://localhost", "56791");
                HttpResponseMessage resposta = await apiRest.Delete("/Api/Usuario/" , id);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }

        }

    } 
}