using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UET_CSE.Startup))]
namespace UET_CSE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
