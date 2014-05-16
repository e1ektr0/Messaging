using System;
using System.Linq;
using System.Web.Mvc;
using DomainEntities;
using Repositories.QueryObject;
using Web.Models.QueryObjects;
using Web.Models.ViewModel.Tables;
using Web.Models.ViewModel.User;

namespace Web.Controllers.Admin
{
    /// <summary>
    /// Контроллер для администрирования списка пользователей
    /// </summary>
    public class AdminUsersController : BaseController
    {
        private readonly QueryExecutor<MembershipUser> _queryExecutor;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AdminUsersController(QueryExecutor<MembershipUser> queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }


        /// <summary>
        /// Вернёт список пользователй
        /// </summary>
        [HttpGet]
        public ActionResult List(UsersQueryObject queryObject)
        {
            if (queryObject == null)
                queryObject = new UsersQueryObject();

            var model = new NotAjaxTable<UserRowModel>(queryObject);
            model.PageItems = _queryExecutor.Fecth<UserRowModel>(queryObject).ToList();
            model.TotalCount = _queryExecutor.Count(queryObject);
            model.FilterAll();
            model.Filter(userModel=>userModel.Id);
            return View(Views.Default.Table, model);
        }


        /// <summary>
        /// Удалить пользователя
        /// </summary>
        [HttpGet]
        public ActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}