using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieCatalogMVC.Startup))]
namespace MovieCatalogMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
