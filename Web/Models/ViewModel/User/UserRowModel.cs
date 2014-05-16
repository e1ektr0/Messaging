using System.ComponentModel;
using Web.Models.Button;

namespace Web.Models.ViewModel.User
{
    /// <summary>
    /// ������ ��� ������ � ������� ������������
    /// </summary>
    public class UserRowModel
    {
        /// <summary>
        /// guid
        /// </summary>
        [DisplayName("�������������")]
        public string Id { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [DisplayName("���")]
        public string FirstName { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [DisplayName("�������")]
        public string LastName { get; set; }

        /// <summary>
        /// ������ ��������
        /// todo:������� buttongroup
        /// </summary>
        [DisplayName("��������")]
        public ButtonActionModel DeleteButton { get; set; }
    }
}