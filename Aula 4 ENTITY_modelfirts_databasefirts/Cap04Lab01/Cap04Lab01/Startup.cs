using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cap04Lab01.Startup))]
namespace Cap04Lab01
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
