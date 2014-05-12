using DomainEntities;

namespace Services.Contracts
{
    /// <summary>
    /// Интефейс для уведомлении клиентов о сообщении
    /// </summary>
    public interface ISendMessageNotification
    {
        /// <summary>
        /// Уведомить получателя о сообщении
        /// </summary>
        void Noty(Message message);
    }
}