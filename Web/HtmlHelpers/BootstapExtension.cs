using System.Web.Mvc;
using Shared.Extensions;

namespace Web.HtmlHelpers
{
    /// <summary>
    /// ��������� ���� ��� ��������� ������ ����������� �� bootstrap
    /// </summary>
    //todo:����������� ��� ������� �������� ������� �������� ��� ������ � ����������
    public static class BootstapExtension
    {
        /// <summary>
        /// ���������� ������ ���� Primory
        /// todo:�������� ������� ��� ������ � ������������� �����
        /// </summary>
        public static MvcHtmlString ButtonPrimory(this HtmlHelper model, string title, string actionLink, string iconName)
        {
            var tag = new TagBuilder("a");
            tag.Attributes["href"] = actionLink;
            tag.AddCssClass("btn");
            tag.AddCssClass("btn-primary");
            if (!iconName.IsNullOrEmpty())
            {
                title = CreateIcon(iconName).ToString(TagRenderMode.Normal) +" "+ title;
            }
            tag.InnerHtml=title;
            return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// ������ ������
        /// </summary>
        private static TagBuilder CreateIcon(string iconName)
        {
            var spanIcon = new TagBuilder("span");
            spanIcon.AddCssClass("glyphicon glyphicon-" + iconName);
            return spanIcon;
        }
    }
}