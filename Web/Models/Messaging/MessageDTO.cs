namespace Web.Models.Dto
{
    /// <summary>
    /// Dto для отправки сообщения
    /// </summary>
    public class MessageDTO
    {
        /// <summary>
        /// Id получателя
        /// </summary>
        public string ReceiverId { get; set; }
        
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Content { get; set; }
    }
}