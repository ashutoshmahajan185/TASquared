using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TASquared.Startup))]
namespace TASquared
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
