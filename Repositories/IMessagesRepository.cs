using System.Collections.Generic;
using DomainEntities;
using Repositories.QueryObject;

namespace Repositories
{
    /// <summary>
    /// Интерфейс репозитория сообщений
    /// </summary>
    public interface IMessagesRepository : IRepository<Message, int>
    {
        /// <summary>
        /// Получить входящии сообщения текущего пользоватлея
        /// </summary>
        IEnumerable<Message> GetInput(QueryObject<Message> queryObject);

        /// <summary>
        /// Получить исходящии сообщения текущего пользователя
        /// </summary>
        IEnumerable<Message> GetOutput(QueryObject<Message> queryObject);
    }
}