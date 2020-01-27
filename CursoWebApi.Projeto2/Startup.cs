using System;
using System.Threading.Tasks;
using System.Web.Http;
using CursoWebApi.Projeto2.Services;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(CursoWebApi.Projeto2.Startup))]

namespace CursoWebApi.Projeto2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            ativarGeracaoToken(app);


        }

        private void ativarGeracaoToken(IAppBuilder app)
        {
            var OpcoesConfigurarToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                TokenEndpointPath = new PathString("\token"),
                Provider = new ProviderDeTokensDeAcesso()
            };

        }
    }
}
