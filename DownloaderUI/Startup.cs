using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DownloaderUI.Startup))]
namespace DownloaderUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
