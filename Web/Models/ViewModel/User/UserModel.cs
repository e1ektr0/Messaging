using System.ComponentModel;
using Web.Models;

namespace Web.Controllers.Admin
{
    public class UserModel
    {
        [DisplayName("�������������")]
        public string Id { get; set; }

        [DisplayName("���")]
        public string FirstName { get; set; }

        [DisplayName("�������")]
        public string LastName { get; set; }

        [DisplayName("��������")]
        public ButtonAction DeleteButton { get; set; }

    }
}