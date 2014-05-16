using System.ComponentModel.DataAnnotations;

namespace Web.Models.ViewModel.Accaunt
{
    /// <summary>
    /// Модель для формы регистрации
    /// </summary>
    public class RegisterViewModel : AccountEditViewModel
    {
        /// <summary>
        /// Поле почты пользователя
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Поле пароля
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Поле подтверждение пароля
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}