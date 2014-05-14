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
            AddOrdering(messageListDTO.GetPropertyName(n => n.SendDate), n=>n.SendDate);
            AddOrdering(messageListDTO.GetPropertyName(n => n.ReceiverName), n=>n.Receiver.FirstName);
            AddOrdering(messageListDTO.GetPropertyName(n => n.SenderName), n=>n.Sender.FirstName);
            AddOrdering(messageListDTO.GetPropertyName(n => n.Subject), n=>n.Subject);
        }
    }


    public class UsersQueryObject : QueryObject<MembershipUser>
    {

    }
}