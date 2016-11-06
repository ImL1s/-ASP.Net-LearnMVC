using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_3.MVC_EF.Startup))]
namespace _3.MVC_EF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
