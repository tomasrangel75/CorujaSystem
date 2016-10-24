using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CorujaSystem.Startup))]
namespace CorujaSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
