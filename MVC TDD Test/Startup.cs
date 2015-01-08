using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_TDD_Test.Startup))]
namespace MVC_TDD_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
