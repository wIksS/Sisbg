using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sisbg.Startup))]
namespace Sisbg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
