using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorAppoinment.Startup))]
namespace DoctorAppoinment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
