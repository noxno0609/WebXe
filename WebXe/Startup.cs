using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebXe.Startup))]
namespace WebXe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
