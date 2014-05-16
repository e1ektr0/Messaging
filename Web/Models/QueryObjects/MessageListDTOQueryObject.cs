using DomainEntities;
using Repositories.QueryObject;
using Web.Models.Dto;

namespace Web.Models.QueryObjects
{
    /// <summary>
    /// Объект запроса для сообщений
    /// </summary>
    public class MessageListDTOQueryObject : ModelQueryObject<MessageListDTO, Message>
    {
        /// <summary>
        /// Конструктор - описывает сортировку
        /// </summary>
        public MessageListDTOQueryObject()
        {
            //Связываем поля dto объекта с правилами сортировки
            AddOrdering(n => n.SendDate, n => n.SendDate);
            AddOrdering(n => n.ReceiverName, n => n.Receiver.FirstName);
            AddOrdering(n => n.SenderName, n => n.Sender.FirstName);
            AddOrdering(n => n.Subject, n => n.Subject);
        }
    }
}