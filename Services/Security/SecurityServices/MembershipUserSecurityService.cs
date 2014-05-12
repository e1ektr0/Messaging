using System.Security.Principal;
using DomainEntities;
using Microsoft.AspNet.Identity;
using Repositories;
using Services.Exceptions;
using Services.Security.SecurityActions;

namespace Services.Security.SecurityServices
{
    /// <summary>
    /// Сревис безопасности для пользователей
    /// </summary>
    public class MembershipUserSecurityService : BaseSecirityService<MembershipUser, DefaultSecurityActions, string>
    {
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        private readonly IPrincipal _principal;

        public MembershipUserSecurityService(IPrincipal principal, IRepository<MembershipUser, string> repository)
            : base(repository)
        {
            _principal = principal;
        }

        /// <summary>
        /// Проверка безопасности
        /// </summary>
        public override void Check(MembershipUser securityObject, DefaultSecurityActions action)
        {
            //Доступ только для аутентифицированых пользователей
            if (!_principal.Identity.IsAuthenticated)
                throw new SecurityException("U need Authenticated");
            switch (action)
            {
                case DefaultSecurityActions.Update:
                    //Действие доступно только для самого пользователя
                    if (securityObject.Id != _principal.Identity.GetUserId())
                        throw new SecurityException("No access");
                    break;

                case DefaultSecurityActions.Delete:
                    //Действие доступно только для самого пользователя
                    if (securityObject.Id != _principal.Identity.GetUserId())
                        throw new SecurityException("No access");
                    break;
            }
        }
    }
}
