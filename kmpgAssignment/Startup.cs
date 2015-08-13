using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kmpgAssignment.Startup))]
namespace kmpgAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
