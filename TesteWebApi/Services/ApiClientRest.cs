﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TesteWebApi.ViewModels;

namespace TesteWebApi.Services
{
    public class ApiClientRest
    {

        string usr;
        string psw;
        string uri;
        string port;
        public HttpClient client;

        public ApiClientRest(string _usr, string _psw, string _uri, string _port)
        {
            this.usr = _usr;
            this.psw = _psw;
            this.uri = _uri;
            this.port = _port;
            this.port = _port;

            this.client = new HttpClient();
            client.BaseAddress = new Uri(_uri+":"+_port);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicarion/json"));


        }

        public  async System.Threading.Tasks.Task<HttpResponseMessage> Get( string path)
        {

            string token = await GetToken("/token"); // 

            this.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage resposta = await this.client.GetAsync(path);  //  GetAsync( client.BaseAddress.ToString()); // 

            return resposta;
        }

        public  async System.Threading.Tasks.Task<HttpResponseMessage> Put( string path, Usuario usuario)
        {

            string token = await GetToken("/token"); // 

            this.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage resposta = await this.client.PutAsJsonAsync(path, usuario);  //  GetAsync( client.BaseAddress.ToString()); // 

            return resposta;
        }

        public async System.Threading.Tasks.Task<HttpResponseMessage> Delete(string path,int  id)
        {

            string token = await GetToken("/token"); // 

            this.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage resposta = await this.client.DeleteAsync(path+'/'+ id);
            
            return resposta;
        }


        private async System.Threading.Tasks.Task<string> GetToken(string path)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.uri+":"+this.port);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicarion/json"));

                var request = new HttpRequestMessage(HttpMethod.Post, path);

                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "username", this.usr },
                    { "password",this.psw},
                    { "grant_type","password"}

                });
                HttpResponseMessage response = await client.SendAsync(request);

                var token = "";
                if (response.IsSuccessStatusCode)
                {
                    var payLoad = JObject.Parse(await response.Content.ReadAsStringAsync());
                    token = payLoad.Value<string>("access_token");
                }

                return token;
            }

        }
    }
}