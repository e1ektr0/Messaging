using System.Web.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Контроллер содержащий описание проекта
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// ReadMe
        /// </summary>
        public ActionResult Index()
        {
            return View(Views.Home.ReadMe);
        }
	}
}