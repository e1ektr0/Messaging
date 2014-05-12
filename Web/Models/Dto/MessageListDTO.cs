namespace Web.Models.Dto
{
    /// <summary>
    /// Dto для объекта сообщения
    /// </summary>
    public class MessageListDTO
    {
        /// <summary>
        /// Id сообщения
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Дата отправки
        /// </summary>
        public string SendDate { get; set; }
        
        /// <summary>
        /// Id отправителя
        /// </summary>
        public string SenderId { get; set; }
        
        /// <summary>
        /// Id получателя
        /// </summary>
        public string ReceiverId { get; set; }
        
        /// <summary>
        /// Имя получателя
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// Email получателя
        /// </summary>
        public string ReceiverEmail { get; set; }
        
        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string SenderName { get; set; }
        
        /// <summary>
        /// Email отправителя
        /// </summary>
        public string SenderEmail { get; set; }
    }
}