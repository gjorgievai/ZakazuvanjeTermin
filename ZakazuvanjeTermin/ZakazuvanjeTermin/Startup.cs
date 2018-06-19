using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZakazuvanjeTermin.Startup))]
namespace ZakazuvanjeTermin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
