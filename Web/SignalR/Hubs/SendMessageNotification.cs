using System.Linq;
using DomainEntities;
using Microsoft.AspNet.SignalR;
using Services.Contracts;
using Shared.Mapper;
using Web.Models.Dto;

namespace Web.SignalR.Hubs
{
    /// <summary>
    /// Отправить уведомление получателю о входящем сообщении
    /// </summary>
    public class SendMessageNotification : ISendMessageNotification
    {
        public void Noty(Message message)
        {
            //Контекст хаба уведомителя
            var context = GlobalHost.ConnectionManager.GetHubContext<MessagesNotificationHub>();

            //Получаем список подключений пользователя
            var connections = BaseUserConnectionsHub.Connections.GetConnections(message.ReceiverId).ToList();

            //Отправляем пользователю уведомление
            context.Clients.Clients(connections).RecieveMessage(message.MapTo(new MessageListDTO()));
        }
    }
}