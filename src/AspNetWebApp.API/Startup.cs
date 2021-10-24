using AspNetWebApp.API.Configs;
using AspNetWebApp.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

namespace AspNetWebApp.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var myProvider = new ApplicationOAuthProvider();            
            
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = myProvider,
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                AllowInsecureHttp = true
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}