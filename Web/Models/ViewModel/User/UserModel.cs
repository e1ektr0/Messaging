using System.ComponentModel;
using Web.Models;

namespace Web.Controllers.Admin
{
    public class UserModel
    {
        [DisplayName("Идентификатор")]
        public string Id { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Дейсвтие")]
        public ButtonAction DeleteButton { get; set; }

    }
}