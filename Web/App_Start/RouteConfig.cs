using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    /// <summary>
    /// Конфигурация роутинга
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Регистрирует роуты
        /// </summary>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
