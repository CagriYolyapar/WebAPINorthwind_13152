using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPINorthwind_1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Eger API development'iniz bittiyse ve  PostMan testleriniz sorunsuz gerçekleştiyse artık yaratmıs oldugunuz API projesinin bilgilerinin baska bir projeden erişilmesi icin hazırlanması gerekmektedir... Baska projelerin bu bilgilere erişebilmesi icin yaratılmıs olan API projesinde bazı ayarlamalar yapmak gerekir...

            //CORS : Cross Origins Resource Server(Manage Nuget Packages  System.Web.HTTp.Cors)

            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");

            config.EnableCors(cors);




            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes(); 

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
