using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTRex.MVC.Startup))]
namespace PTRex.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
