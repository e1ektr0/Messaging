using System.Web.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Контроллер сообщений
    /// </summary>
    [Authorize]
    public class MessagingController : BaseController
    {
        /// <summary>
        /// Стартовая страница для работы с сообщениями
        /// </summary>
        public ActionResult Index()
        {
            return View(Views.Messaging.List);
        }

        /// <summary>
        /// Шаблон списка пользователей
        /// </summary>
        public ActionResult Users()
        {
            return PartialView(Views.Messaging.UsersList);
        }

        /// <summary>
        /// Шаблон списка сообщений
        /// </summary>
        public ActionResult Messages()
        {
            return PartialView(Views.Messaging.MessageList);
        }

        /// <summary>
        /// Шаблон просмотра сообщений
        /// </summary>
        /// <returns></returns>
        public ActionResult MessageRead()
        {
            return PartialView(Views.Messaging.MessageRead);
        }

        /// <summary>
        /// Шаблон написания сообщений
        /// </summary>
        public ActionResult MessageWrite()
        {
            return PartialView(Views.Messaging.MessageWrite);
        }
    }
}