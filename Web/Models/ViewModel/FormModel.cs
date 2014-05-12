using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SharedStrings;

namespace Web.Models.ViewModel
{
    /// <summary>
    /// Модель для формы
    /// </summary>
    public abstract class FormModel
    {
        /// <summary>
        /// Модель для рендеринга формы
        /// </summary>
        [Required]
        public object Model { get; set; }

        /// <summary>
        /// Заголовок формы
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.Title)]
        public string Title { get; set; }

        /// <summary>
        /// Подзаголовок
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.Subtitle)]
        public string SubTitle { get; set; }
    }
}