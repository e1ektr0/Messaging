using System.ComponentModel.DataAnnotations;

namespace Web.Models.ViewModel.Accaunt
{
    /// <summary>
    /// ������ ����� �����������
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// �������� �����
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}