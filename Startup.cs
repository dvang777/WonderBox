using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WonderBox.Startup))]
namespace WonderBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
