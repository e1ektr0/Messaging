using System.ComponentModel.DataAnnotations;
using SharedStrings;

namespace Web.Models.ViewModel.Accaunt
{
    /// <summary>
    /// Модель редактирования профиля пользователя
    /// </summary>
    public class AccountEditViewModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "First Name")]
        [RegularExpression(ConstantStrings.UserNameEmailRegex, ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Last Name")]
        [RegularExpression(ConstantStrings.UserNameEmailRegex, ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
