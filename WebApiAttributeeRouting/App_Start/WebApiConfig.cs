using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using WebApiAttributeeRouting.Custom;

namespace WebApiAttributeeRouting
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) 
        {
            // Web API configuration and services
            

            // Web API routes
            config.MapHttpAttributeRoutes();

            // config.Routes.MapHttpRoute(
            //    name: "Version1",
            //    routeTemplate: "api/v1/{studentsversion1}/{id}",
            //    defaults: new { id = RouteParameter.Optional,controller="StudentVersion1" }
            //);

            // config.Routes.MapHttpRoute(
            //    name: "Version2",
            //    routeTemplate: "api/v2/{studentsversion2}/{id}",
            //    defaults: new { id = RouteParameter.Optional,controller="StudentVersion2" }
            //);

            // config.Routes.MapHttpRoute(
            //     name: "DefaultApi",
            //     routeTemplate: "api/{controller}/{id}",
            //     defaults: new { id = RouteParameter.Optional }
            // );

            //for querystring versioning
            config.Routes.MapHttpRoute(
               name: "DefaultRoute",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));
           

        }
    }
}
