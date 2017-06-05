using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecruitSpike.Startup))]
namespace RecruitSpike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
