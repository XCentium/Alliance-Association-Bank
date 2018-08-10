using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllianceAssociationBank.Crm.Startup))]
namespace AllianceAssociationBank.Crm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
