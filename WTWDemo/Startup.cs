using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WTWDemo.Startup))]
namespace WTWDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
