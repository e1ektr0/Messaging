using System.Web.Mvc;

namespace Web.HtmlHelpers
{
    /// <summary>
    /// Хелпер для формирования в razor div с классом form-group
    /// </summary>
    public class FormGroup
    {
        private readonly TagBuilder _formGroup;

        /// <summary>
        /// Конструктор
        /// </summary>
        public FormGroup(TagBuilder formGroup)
        {
            _formGroup = formGroup;
        }

        /// <summary>
        /// Генрирует начало тега
        /// </summary>
        public MvcHtmlString Begin()
        {
            return new MvcHtmlString(_formGroup.ToString(TagRenderMode.StartTag));
        }

        /// <summary>
        /// Генерирует конец тега
        /// </summary>
        public MvcHtmlString End()
        {
            return new MvcHtmlString(_formGroup.ToString(TagRenderMode.EndTag));
        }
    }
}