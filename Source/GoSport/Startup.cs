using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoSport.Startup))]
namespace GoSport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
