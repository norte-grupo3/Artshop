using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtShop.UI.WebSite.Startup))]
namespace ArtShop.UI.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
