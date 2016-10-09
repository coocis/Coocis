using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Coocis.Startup))]
namespace Coocis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
