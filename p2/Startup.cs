using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(p2.Startup))]
namespace p2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
