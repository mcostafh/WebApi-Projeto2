using CursoWebApi.Projeto2.Models;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CursoWebApi.Projeto2.Services
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            LoginsSistema login = LoginsAutentication.Login(context.UserName, context.Password);

            if (login != null  )
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Usuário_Logado", context.UserName));
                identity.AddClaim(new Claim( ClaimTypes.Role, login.Role));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Acesso invádido", "As credenciais informadas não são válidas");
            }
            return base.GrantResourceOwnerCredentials(context);
        }
    }
}