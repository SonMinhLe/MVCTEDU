using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTEDU.Startup))]
namespace MVCTEDU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
