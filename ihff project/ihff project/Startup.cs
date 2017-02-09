using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ihff_project.Startup))]
namespace ihff_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
