using System.Web.Mvc;

namespace Web.HtmlHelpers
{
    /// <summary>
    /// Хелпер для формирования в razor div с классом form-group
    /// </summary>
    public class FormGroup
    {
        private readonly TagBuilder _formGroup;

        public FormGroup(TagBuilder formGroup)
        {
            _formGroup = formGroup;
        }

        public MvcHtmlString Begin()
        {
            return new MvcHtmlString(_formGroup.ToString(TagRenderMode.StartTag));
        }

        public MvcHtmlString End()
        {
            return new MvcHtmlString(_formGroup.ToString(TagRenderMode.EndTag));
        }
    }
}