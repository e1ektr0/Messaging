using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SharedStrings;

namespace Web.Models.ViewModel
{
    /// <summary>
    /// ������ ��� �����
    /// </summary>
    public abstract class FormModel
    {
        /// <summary>
        /// ������ ��� ���������� �����
        /// </summary>
        [Required]
        public object Model { get; set; }

        /// <summary>
        /// ��������� �����
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.Title)]
        public string Title { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [AdditionalMetadata(ConstantStrings.FormPropertyValue, ConstantStrings.FormProperty.Subtitle)]
        public string SubTitle { get; set; }
    }
}