using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllianceAssociationBank.Crm
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            // Enables attribute routing
            routes.MapMvcAttributeRoutes();

            AreaRegistration.RegisterAllAreas(); // Added this new!

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {
                    controller = ControllerName.Home,
                    action = HomeControllerAction.Index,
                    id = UrlParameter.Optional }
            );
        }
    }
}
