using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        /// <summary>
        /// Финвигурирует что то..todo:понять что
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
