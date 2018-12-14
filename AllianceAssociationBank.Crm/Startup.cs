using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Providers;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(AllianceAssociationBank.Crm.Startup))]
namespace AllianceAssociationBank.Crm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureLogger();

            ControllerBuilder.Current.SetControllerFactory(new SessionStateControllerFactory());

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = new HttpConfiguration();
            ConfigureAuth(app);
            app.UseWebApi(config);
        }
    }
}
