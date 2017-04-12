using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eventis.Startup))]
namespace Eventis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
