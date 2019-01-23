using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeekPeeked.Startup))]
namespace GeekPeeked
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
