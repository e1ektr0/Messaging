using System.Web.Mvc;
using SharedStrings;

namespace Web.Models.ViewModel
{
    /// <summary>
    /// Баовая модель для формы редактирования
    /// </summary>
    public class EditBaseModel: BaseModel
    {
        /// <summary>
        /// Имя дествия для обработки формы
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.Action)]
        public string Action { get; set; }

        /// <summary>
        /// Имя контроллера для обработки формы
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.Controller)]
        public string Controller { get; set; }

        /// <summary>
        /// Надпись на кнопку отправки формы
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.SubmitButtonTitle)]
        public string ButtonTitle { get; set; }
    }
}