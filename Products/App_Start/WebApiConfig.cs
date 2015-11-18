using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Products
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            //Response.AppendHeader("Access-Control-Allow-Origin", "*");
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("http://myblogblog.esy.es", "*", "*");
            config.EnableCors(cors);

            //added starts
            config.Routes.MapHttpRoute(
                name: "DefaultApiWithExtensions",
                routeTemplate: "{controller}.{ext}/{action}",
                defaults: new {ext = "json", action = "Get", showHelp = true}
            );
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}",
                defaults: new { ext = "json", action = "Get", showHelp = false }
            );
            config.Formatters.JsonFormatter.AddQueryStringMapping("responseContentType", "json", "application/json");
            config.Formatters.XmlFormatter.AddQueryStringMapping("responseContentType", "xml", "application/xml");

            //added ends
            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/
        }
    }
}
