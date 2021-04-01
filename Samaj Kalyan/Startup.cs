using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Samaj_Kalyan.Startup))]
namespace Samaj_Kalyan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
