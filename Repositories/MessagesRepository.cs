using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using DataBaseModel;
using DomainEntities;
using Microsoft.AspNet.Identity;
using Repositories.QueryObject;

namespace Repositories
{
    /// <summary>
    /// Репозиторий для сообщений
    /// </summary>
    public class MessagesRepository : IMessagesRepository
    {
        #region Constructor & properties

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        private readonly IPrincipal _user;

        /// <summary>
        /// Контекст сообщений
        /// </summary>
        private readonly IContext<Message> _context;

        public MessagesRepository(IContext<Message> context, IPrincipal user)
        {
            _context = context;
            _user = user;
        }

        #endregion Constructor & properties

        #region Methods

        /// <summary>
        /// Получить сообщения по id
        /// </summary>
        public virtual Message GetById(int id)
        {
            return _context.Table.FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// Получить входящии сообщения текущего пользоватлея
        /// </summary>
        public virtual IEnumerable<Message> GetInput(QueryObject<Message> queryObject)
        {
            var userid = _user.Identity.GetUserId();
            var query = _context.Table.Where(n => n.ReceiverId == userid && !n.DeleteReceiver);
            query = queryObject.Query(query).Include(n => n.Receiver).Include(n => n.Sender);
            return query.ToList();
        }

        /// <summary>
        /// Получить исходящии сообщения текущего пользователя
        /// </summary>
        public virtual IEnumerable<Message> GetOutput(QueryObject<Message> queryObject)
        {
            var userid = _user.Identity.GetUserId();
            var query = _context.Table.Where(n => n.SenderId == userid && !n.DeleteSender);
            query = queryObject.Query(query).Include(n => n.Receiver).Include(n => n.Sender);
            return query.ToList();
        }

        #endregion Methods
    }
}
