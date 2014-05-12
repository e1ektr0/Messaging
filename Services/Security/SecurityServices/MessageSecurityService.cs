using System.Security.Principal;
using DomainEntities;
using Microsoft.AspNet.Identity;
using Repositories;
using Services.Exceptions;
using Services.Security.SecurityActions;

namespace Services.Security.SecurityServices
{
    /// <summary>
    /// Сервис безопасности для сообщений
    /// </summary>
    public class MessageSecurityService : BaseSecirityService<Message, MessageSecurityActions, int>
    {
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        private readonly IPrincipal _principal;

        public MessageSecurityService(IPrincipal principal, IRepository<Message, int> repository)
            : base(repository)
        {
            _principal = principal;
        }

        /// <summary>
        /// Проверка доступа
        /// </summary>
        public override void Check(Message securityObject, MessageSecurityActions action)
        {
            //Для работы с сообщениями требуется аутентификация
            if (!_principal.Identity.IsAuthenticated)
                throw new SecurityException("U need Authenticated!");

            var userId = _principal.Identity.GetUserId();
            switch (action)
            {
                case MessageSecurityActions.GetById:
                    //Проверяет что у текущего пользователя есть доступ к объекту
                    if (securityObject == null)
                        throw new SecurityException("Requested object not found!");
                    if (securityObject.ReceiverId != userId && securityObject.SenderId != userId)
                        throw new SecurityException("U have not access to this message");
                    break;

                case MessageSecurityActions.Send:
                    //Проверяет что отправитель и получатель указаны корректно
                    if (securityObject == null || securityObject.SenderId != userId)
                        throw new SecurityException("U should send this message");
                    if(securityObject.ReceiverId == null)
                        throw new SecurityException("No receiver");
                    break;

                case MessageSecurityActions.DeleteInput:
                    //Действие доступно только для владельца
                    if (securityObject == null || securityObject.ReceiverId != userId)
                        throw new SecurityException("U should recive this message for delete");
                    break;

                case MessageSecurityActions.DeleteOutput:
                    //Действие доступно только для владельца
                    if (securityObject == null || securityObject.SenderId != userId)
                        throw new SecurityException("U should send this message for delete");
                    break;
            }
        }
    }
}