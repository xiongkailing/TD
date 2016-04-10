using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamDay.WebSite.Startup))]
namespace TeamDay.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
