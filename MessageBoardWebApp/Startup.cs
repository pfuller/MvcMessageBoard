using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MessageBoardWebApp.Startup))]
namespace MessageBoardWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
