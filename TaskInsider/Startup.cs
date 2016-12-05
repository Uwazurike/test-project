using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskInsider.Startup))]
namespace TaskInsider
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
