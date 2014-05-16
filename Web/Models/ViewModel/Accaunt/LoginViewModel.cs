using System.ComponentModel.DataAnnotations;

namespace Web.Models.ViewModel.Accaunt
{
    /// <summary>
    /// Модель формы авторизации
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Почтовый адрес
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}