using Web.Controllers.Admin;

namespace Web.Models.Button
{
    /// <summary>
    /// ������ ������
    /// </summary>
    public class ButtonActionModel
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ������ �� ��������
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// ��� ������
        /// </summary>
        public ButtonTypes? Type { get; set; }
    }
}