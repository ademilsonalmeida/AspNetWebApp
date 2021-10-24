using AspNetWebApp.API.Configs;
using System;
using System.Web;
using System.Web.Http;

namespace AspNetWebApp.API
{
    public class Global : HttpApplication
    {

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(SwaggerConfig.Register);
        }        
    }
}