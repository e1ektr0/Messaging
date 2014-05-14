using System;
using System.Linq.Expressions;
using DomainEntities;
using Repositories.QueryObject;
using Shared.Extensions;
using Web.Models.Dto;

namespace Web.Models.QueryObjects
{
    /// <summary>
    /// Объект запроса для сообщений
    /// </summary>
    public class MessageListDTOQueryObject : QueryObject<Message>
    {
        public MessageListDTOQueryObject()
        {
            var messageListDTO = new MessageListDTO();
            //Связываем поля dto объекта с правилами сортировки
            AddOrdering(messageListDTO.GetPropertyName(n => n.SendDate), n => n.SendDate);
            AddOrdering(messageListDTO.GetPropertyName(n => n.ReceiverName), n => n.Receiver.FirstName);
            AddOrdering(messageListDTO.GetPropertyName(n => n.SenderName), n => n.Sender.FirstName);
            AddOrdering(messageListDTO.GetPropertyName(n => n.Subject), n => n.Subject);
        }
    }


    public class UsersQueryObject : QueryObject<MembershipUser>
    {
        protected override Expression<Func<MembershipUser, bool>> Filter()
        {
            var filter = base.Filter();
            //filter.And(n => n.Id == "");
            return filter;
        }
    }
}