using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TesteWebApi.ViewModels;

namespace TesteWebApi.Controllers
{
    public class UsuarioController : Controller
    {
        static IEnumerable<Cidade> cidade = null;

        private async System.Threading.Tasks.Task<IEnumerable<Cidade>> GetCidadesAsync()
        {
            IEnumerable<Cidade> cidades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65462/Api/cidades");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicarion/json"));

                string token = await AutenticacaoUsuario.getTokenAsync();
                client.DefaultRequestHeaders.Add("Autorization", "bearer "+token);

                HttpResponseMessage resposta = await client.GetAsync( client.BaseAddress.ToString());

                if (resposta.IsSuccessStatusCode)
                {
                    var conteudo = resposta.Content.ReadAsStringAsync().Result;
                    cidades = JsonConvert.DeserializeObject<Cidade[]>(conteudo);


                }


                return cidades;
            }



        }

        // GET: Usuario
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
           // IEnumerable<Cidade> cidades =  await GetCidadesAsync();

            
            IEnumerable<Usuario> usuarios = null;

            using (var client = new HttpClient())
            {
                string token = await AutenticacaoUsuario.getTokenAsync();

                client.BaseAddress = new Uri("http://localhost:56791/Api/Usuario");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicarion/json"));

                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

                HttpResponseMessage resposta = await client.GetAsync(client.BaseAddress.ToString());

                if (resposta.IsSuccessStatusCode)
                {
                    var conteudo = resposta.Content.ReadAsStringAsync().Result;
                    usuarios = JsonConvert.DeserializeObject<Usuario[]>(conteudo);


                }

            }


            return View(usuarios);
        }
    }
}