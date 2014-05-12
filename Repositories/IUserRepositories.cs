using System.Collections.Generic;
using DomainEntities;

namespace Repositories
{
    /// <summary>
    /// Интерфейс репозитория пользователей
    /// </summary>
    public interface IUserRepositories : IRepository<MembershipUser, string>
    {
        /// <summary>
        /// Получить список пользователей для отправки сообщений
        /// </summary>
        IEnumerable<MembershipUser> GetUsersForSendMessage();
    }
}