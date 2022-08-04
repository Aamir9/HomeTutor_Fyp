using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeTutor.Startup))]
namespace HomeTutor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
