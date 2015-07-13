using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaliforniaPep.Startup))]
namespace CaliforniaPep
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
