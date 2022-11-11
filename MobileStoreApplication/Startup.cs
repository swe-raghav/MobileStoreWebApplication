using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileStoreApplication.Startup))]
namespace MobileStoreApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
