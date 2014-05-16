using System.ComponentModel.DataAnnotations;

namespace Web.Models.ViewModel
{
    /// <summary>
    /// Модель формы авторизации
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}