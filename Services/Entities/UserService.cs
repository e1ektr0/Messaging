using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DomainEntities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Services.Exceptions;
using Services.Security;
using Services.Security.SecurityActions;

namespace Services.Entities
{
    /// <summary>
    /// Сервис для работы с акаунтом
    /// </summary>
    public class UserService
    {
        #region Constructor & properties

        /// <summary>
        /// Менеджер пользоватлей 
        /// </summary>
        private readonly UserManager<MembershipUser> _userManager;

        /// <summary>
        /// Сервис безопастности пользователей
        /// </summary>
        private readonly ISecurityService<MembershipUser, DefaultSecurityActions> _securityService;

        public UserService(
            UserManager<MembershipUser> userManager,
            ISecurityService<MembershipUser,
            DefaultSecurityActions> securityService)
        {
            _userManager = userManager;
            _securityService = securityService;
        }

        #endregion Constructor & properties

        #region Public Methods

        /// <summary>
        /// Зарегистрировать пользователея
        /// </summary>
        public async Task<MembershipUser> Register(MembershipUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new ServiceException(result.Errors.FirstOrDefault());

            await SignInAsync(user);
            return user;
        }

        /// <summary>
        /// Залогиниться
        /// </summary>
        public async Task Login(string email, string password)
        {
            var user = await _userManager.FindAsync(email, password);
            if (user != null)
                await SignInAsync(user);
            else
                throw new ServiceException("The email or password you entered is incorrect.");
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        public async Task Update(MembershipUser user)
        {
            _securityService.Check(user, DefaultSecurityActions.Update);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new ServiceException(result.Errors.FirstOrDefault());
        }

        /// <summary>
        /// Разлогиниться
        /// </summary>
        public void SignOut()
        {
            GetAuthenticationManager().SignOut();
        }

        #endregion  Public Methods

        #region Private Methods

        /// <summary>
        /// Получить менеджер аутентификации
        /// </summary>
        private IAuthenticationManager GetAuthenticationManager()
        {
            return HttpContext.Current.GetOwinContext().Authentication;
        }

        /// <summary>
        /// Зайти с предварительным выходом
        /// </summary>
        private async Task SignInAsync(MembershipUser user)
        {
            GetAuthenticationManager().SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            GetAuthenticationManager().SignIn(new AuthenticationProperties(), identity);
        }

        #endregion  Private Methods
    }
}
