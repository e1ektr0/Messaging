using System.Web.Http;

namespace Web
{
    /// <summary>
    /// Конфиг api
    /// </summary>
    public class WebApiConfig
    {
        /// <summary>
        /// Регистрируем рутинг
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}