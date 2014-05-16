using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Web.Controllers.Admin;

namespace Web.Models.Button
{
    /// <summary>
    /// Фабрика кнопок
    /// </summary>
    public class ButtonFactory
    {
        //todo:разработать модуль строготипизированых ссылок или упередь откуданить
        /// <summary>
        /// Содаёт кнопку удаления
        /// </summary>
        public ButtonActionModel DeleteButton<TController>(Expression<Func<TController, ActionResult>> action, string title = "Удалить") where TController : Controller
        {
            var url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);

            return new ButtonActionModel { Title = title, Action = url.Action(action), Type = ButtonTypes.Trash };
        }
    }
}