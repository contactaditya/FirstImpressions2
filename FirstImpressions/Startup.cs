using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstImpressions.Startup))]
namespace FirstImpressions
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
