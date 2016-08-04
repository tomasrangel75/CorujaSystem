using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CorujaPresentation.Startup))]
namespace CorujaPresentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
