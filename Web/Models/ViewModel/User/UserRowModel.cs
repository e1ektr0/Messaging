using System.ComponentModel;
using Web.Models.Button;

namespace Web.Models.ViewModel.User
{
    /// <summary>
    /// Модель для строки в таблице пользователй
    /// </summary>
    public class UserRowModel
    {
        /// <summary>
        /// guid
        /// </summary>
        [DisplayName("Идентификатор")]
        public string Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Кнопка удаления
        /// todo:сделать buttongroup
        /// </summary>
        [DisplayName("Дейсвтие")]
        public ButtonActionModel DeleteButton { get; set; }
    }
}