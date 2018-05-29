using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingsForAllDay.Startup))]
namespace TrainingsForAllDay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
