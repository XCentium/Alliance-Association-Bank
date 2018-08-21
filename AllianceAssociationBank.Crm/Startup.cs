using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(AllianceAssociationBank.Crm.Startup))]
namespace AllianceAssociationBank.Crm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            ConfigureAuth(app);
        }
    }
}
