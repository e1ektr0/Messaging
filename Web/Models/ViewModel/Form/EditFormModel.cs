using System.Web.Mvc;
using SharedStrings;

namespace Web.Models.ViewModel
{
    /// <summary>
    /// ������ ������ ��� ����� ��������������
    /// </summary>
    public class EditBaseModel: BaseModel
    {
        /// <summary>
        /// ��� ������� ��� ��������� �����
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.Action)]
        public string Action { get; set; }

        /// <summary>
        /// ��� ����������� ��� ��������� �����
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.Controller)]
        public string Controller { get; set; }

        /// <summary>
        /// ������� �� ������ �������� �����
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.SubmitButtonTitle)]
        public string ButtonTitle { get; set; }
    }
}