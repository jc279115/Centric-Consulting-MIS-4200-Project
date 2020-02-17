using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Centric_Consulting_MIS_4200_Project.Startup))]
namespace Centric_Consulting_MIS_4200_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
