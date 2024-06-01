using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace backend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsMessageHandler());
            var corsPolicy = new System.Web.Cors.CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                SupportsCredentials = true
            };
            corsPolicy.Origins.Add("http://localhost:3000");

            
        }
        public class CorsMessageHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = base.SendAsync(request, cancellationToken);

                response.Result.Headers.Add("Access-Control-Allow-Origin", "*");
                response.Result.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                response.Result.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, Accept, Authorization");
               
            

                return response;
            }
        }
    }
}
