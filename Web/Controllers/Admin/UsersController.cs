using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using AutoMapper;
using DomainEntities;
using Repositories;
using Shared.Mapper;
using Web.MapperConfigs;
using Web.Models.ViewModel;

namespace Web.Controllers.Admin
{
    public class UsersController : BaseController
    {
        private readonly UsersRepository _usersRepository;

        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        [HttpGet]
        public ActionResult List()
        {
            var users = _usersRepository.SelectAll();
            var model = new NotAjaxTable<UserModel>();
            model.PageItems = users.Select(n => n.MapTo(new UserModel())).ToList();
            return View(Views.Default.Table, model);
        }


        public ActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }

    public class UserModel
    {
        [DisplayName("Идентификатор")]
        public string Id { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Дейсвтие")]
        public ButtonAction DeleteButton { get; set; }

    }

    public class ButtonAction
    {
        public string Title { get; set; }
        public string Action { get; set; }
    }

    public class ButtonFactory
    {
        //todo:разработать модуль строготипизированых ссылок или упередь откуданить
        public ButtonAction DeleteButton<TController>(Expression<Func<TController, ActionResult>> action, object parameters, string title = "Удалить") where TController : Controller
        {
            var url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
            return new ButtonAction { Title = title, Action = url.Action(action.Name, BaseController.ControllerNameByType(typeof(TController)), parameters) };
        }
    }

    public class UserModelMapperConfig : EntityModelBaseMapConfig<MembershipUser, UserModel>
    {
        private readonly ButtonFactory _buttonFactory;

        public UserModelMapperConfig(ButtonFactory buttonFactory)
        {
            _buttonFactory = buttonFactory;
        }

        protected override void MapToModel(IMappingExpression<MembershipUser, UserModel> map)
        {
            map.AfterMap((entity, model) =>model.DeleteButton = _buttonFactory.DeleteButton<UsersController>(x => x.Delete(entity.Id), new {entity.Id}));
        }

        protected override void MapToEntity(IMappingExpression<UserModel, MembershipUser> map)
        {
        }
    }

}