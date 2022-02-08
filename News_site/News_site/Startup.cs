using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(News_site.Startup))]
namespace News_site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
