﻿using AllianceAssociationBank.Crm.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace AllianceAssociationBank.Crm
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new WebApiDefaultExceptionFilter(Log.Logger));

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Register Unity with WebApi
            config.DependencyResolver = new Unity.AspNet.WebApi.UnityDependencyResolver(UnityConfig.Container);
        }
    }
}
