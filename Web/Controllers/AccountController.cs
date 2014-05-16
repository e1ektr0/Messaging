using System.Threading.Tasks;
using System.Web.Mvc;
using DomainEntities;
using Microsoft.AspNet.Identity;
using Repositories;
using Services.Entities;
using Shared.Exceptions;
using Shared.Mapper;
using Web.Models.ViewModel;
using Web.Models.ViewModel.Accaunt;

namespace Web.Controllers
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class AccountController : BaseController
    {
        /// <summary>
        /// Сервис пользователей
        /// </summary>
        private readonly UserService _userService;
        
        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        private readonly UsersRepository _usersRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AccountController(UserService userService, UsersRepository usersRepository)
        {
            _userService = userService;
            _usersRepository = usersRepository;
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return EditView(model, Register, "Register", "Create a new account", "Register");
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectWithState(Register);
            try
            {
                var user = AutoMapper.Mapper.Map<MembershipUser>(model);
                await _userService.Register(user, model.Password);
                return RedirectTo<MessagingController>(n=>n.Index());
            }
            catch (BaseCustomException e)
            {
                return RedirectWithState(Register, e);
            }
        }

        /// <summary>
        /// Редактирование профиля
        /// </summary>
        [HttpGet]
        [Authorize]
        public ActionResult Edit()
        {
            var domaintUser = _usersRepository.GetById(User.Identity.GetUserId());
            var model = AutoMapper.Mapper.Map<AccountEditViewModel>(domaintUser);
            return EditView(model, Edit, "Edit", "Edit an account", "Edit");
        }

        /// <summary>
        /// Редактирование профиля
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AccountEditViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectWithState(Edit);
            
            try
            {
                var domaintUser = _usersRepository.GetById(User.Identity.GetUserId());
                model.MapTo(domaintUser);
                await _userService.Update(domaintUser);
                return RedirectTo<AccountController>(n => n.Edit());
            }
            catch (BaseCustomException e)
            {
                return RedirectWithState(Edit, e);
            }
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return EditView(model, Login, "Login", "Use a local account to log in.", "Login");
        }
        
        /// <summary>
        /// Авторизация
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectWithState(Login);

            try
            {
                await _userService.Login(model.Email, model.Password);
                return RedirectTo<MessagingController>(n => n.Index());
            }
            catch (BaseCustomException e)
            {
                return RedirectWithState(Login, e);
            }
        }

        /// <summary>
        /// Выйти
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _userService.SignOut();
            return RedirectTo<AccountController>(n=>n.Login());
        }
    }
}