using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControllerInjection.Startup))]
namespace ControllerInjection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
