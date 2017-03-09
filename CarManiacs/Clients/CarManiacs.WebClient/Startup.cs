using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarManiacs.WebClient.Startup))]
namespace CarManiacs.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
