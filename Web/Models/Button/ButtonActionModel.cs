using Web.Controllers.Admin;

namespace Web.Models.Button
{
    /// <summary>
    /// Модель кнопки
    /// </summary>
    public class ButtonActionModel
    {
        /// <summary>
        /// Заголовк
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Ссылка на действие
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Тип кнопки
        /// </summary>
        public ButtonTypes? Type { get; set; }
    }
}