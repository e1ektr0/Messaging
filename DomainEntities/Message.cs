using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainEntities
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message : IKeyEntity<int>
    {
        #region Properties

        /// <summary>
        /// Id сообщения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id отправителя
        /// </summary>
        public string SenderId { get; set; }

        /// <summary>
        /// Id получателя
        /// </summary>
        public string ReceiverId { get; set; }

        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Тест сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Флаг - отправитель удалил сообщение
        /// </summary>
        public bool DeleteSender { get; set; }

        /// <summary>
        /// Флаг - получатель удалил сообщение
        /// </summary>
        public bool DeleteReceiver { get; set; }

        #endregion Properties

        #region Relations

        /// <summary>
        /// Отправитель
        /// </summary>
        [ForeignKey("SenderId")]
        public virtual MembershipUser Sender { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        [ForeignKey("ReceiverId")]
        public virtual MembershipUser Receiver { get; set; }

        #endregion Relations
    }
}