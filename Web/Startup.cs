using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ngSpa.Web.Startup))]
namespace ngSpa.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
