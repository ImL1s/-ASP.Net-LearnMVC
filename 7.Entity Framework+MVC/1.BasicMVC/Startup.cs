using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1.BasicMVC.Startup))]
namespace _1.BasicMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
