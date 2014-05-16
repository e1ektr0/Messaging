using System;
using System.Linq;
using System.Web.Mvc;
using DomainEntities;
using Repositories;
using Web.Models.QueryObjects;
using Web.Models.ViewModel;

namespace Web.Controllers.Admin
{
    public class UsersController : BaseController
    {
        private readonly QueryExecutor<MembershipUser> _queryExecutor;

        public UsersController(QueryExecutor<MembershipUser> queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }


        [HttpGet]
        public ActionResult List(UsersQueryObject queryObject)
        {
            if (queryObject == null)
                queryObject = new UsersQueryObject();

            var model = new NotAjaxTable<UserModel>(queryObject);

            model.PageItems = _queryExecutor.Fecth<UserModel>(queryObject).ToList();
            model.TotalCount = _queryExecutor.Count(queryObject);
            model.FilterAll();
            model.Filter(userModel=>userModel.Id);
            return View(Views.Default.Table, model);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}