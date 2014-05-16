using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers.Admin
{
    public class ButtonFactory
    {
        //todo:разработать модуль строготипизированых ссылок или упередь откуданить
        public ButtonAction DeleteButton<TController>(Expression<Func<TController, ActionResult>> action, string title = "Удалить") where TController : Controller
        {
            var url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);

            return new ButtonAction { Title = title, Action = url.Action(action), Type = ButtonTypes.Trash };
        }
    }
}