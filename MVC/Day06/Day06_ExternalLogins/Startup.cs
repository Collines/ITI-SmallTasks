using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Day06_ExternalLogins.Startup))]
namespace Day06_ExternalLogins
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
