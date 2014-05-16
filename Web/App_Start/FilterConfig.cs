using System.Web.Mvc;

namespace Web
{
    /// <summary>
    /// Конфигурирования фильтров
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Регистрируем глобальные фильтры
        /// </summary>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
