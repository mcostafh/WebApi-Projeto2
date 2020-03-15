using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace TesteWebApi
{
    public static class AutenticacaoUsuario
    {
        public static string username = "nel";
        public static  string password = "12";
        public static string token = "";

        public static async System.Threading.Tasks.Task<string> getTokenAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56791/token");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicarion/json"));



                var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress.ToString());

                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "username", username },
                    { "password",password},
                    { "grant_type","password"}

                });
                var response = await client.SendAsync(request);

                var token = "";
                if (response.IsSuccessStatusCode) { 
                    var payLoad = JObject.Parse(await response.Content.ReadAsStringAsync());
                    token = payLoad.Value<string>("access_token");
                }

                return token;
            }
        }

    }
}