using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Web.Models.ViewModel;

namespace Web.Controllers
{
    /// <summary>
    /// Базоый контроллер
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Ключь хранения ViewData при передаче между экшенами во время редиректа
        /// </summary>
        private const string ViewDataKey = "ViewData";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Передача ViewData
            if (TempData[ViewDataKey] != null)
            {
                ViewData = (ViewDataDictionary)TempData[ViewDataKey];
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Генерация представления для формы редактирования
        /// </summary>
        protected ActionResult EditView<TModel>(TModel model, Func<ActionResult> action, string title, string subtitle, string submitTitle)
        {
            var editFormModel = new EditBaseModel { Model = model };
            editFormModel.Title = title;
            editFormModel.SubTitle = subtitle;
            editFormModel.Action = action.Method.Name;
            editFormModel.Controller = CurrentControllerName();
            editFormModel.ButtonTitle = submitTitle;
            return View(Views.Default.Edit, editFormModel);
        }

        /// <summary>
        /// Получение имени текущего контроллера
        /// </summary>
        /// <returns></returns>
        private string CurrentControllerName()
        {
            return ControllerNameByType(GetType());
        }

        /// <summary>
        /// Тип контроллера
        /// </summary>
        public static string ControllerNameByType(Type type)
        {
            var name = type.Name;
            return name.Substring(0, name.Length - "Controller".Length);
        }

        /// <summary>
        /// Редирект с сохранением всех ошибок, произошедших при валидации модели
        /// </summary>
        protected ActionResult RedirectWithState(string action, string controller)
        {
            TempData[ViewDataKey] = ViewData;
            return RedirectToAction(action, controller);
        }
        /// <summary>
        /// Редирект с сохранением всех ошибок произошедших при валидации модели
        /// </summary>
        protected ActionResult RedirectWithState(Func<ActionResult> action)
        {
            TempData[ViewDataKey] = ViewData;
            return RedirectToAction(action.Method.Name);
        }
        /// <summary>
        /// Редирект с сохранением всех ошибок произошедших при валидации модели
        /// </summary>
        protected ActionResult RedirectWithState(Func<ActionResult> action, Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return RedirectWithState(action);
        }

        /// <summary>
        /// Редирект с сохранением всех ошибок произошедших при валидации модели
        /// </summary>
        protected ActionResult RedirectTo<TController>(Expression<Func<TController, ActionResult>> action)
        {
            var methodCallExpression = action.Body as MethodCallExpression;
            if(methodCallExpression == null)
                throw new Exception("should be MethodCallExpression");
            return RedirectWithState(methodCallExpression.Method.Name, ControllerNameByType(typeof(TController)));
        }
    }
}