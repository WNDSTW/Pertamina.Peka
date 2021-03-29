using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pertamina.Peka.Startup))]
namespace Pertamina.Peka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
