using System.ComponentModel.DataAnnotations;
using SharedStrings;

namespace Web.Models.ViewModel
{
    /// <summary>
    /// Модель редактирования профиля пользователя
    /// </summary>
    public class AccountEditViewModel
    {
        [Display(Name = "First Name")]
        [RegularExpression(ConstantStrings.UserNameEmailRegex, ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(ConstantStrings.UserNameEmailRegex, ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
