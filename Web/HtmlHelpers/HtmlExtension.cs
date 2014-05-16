using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Shared.Extensions;

namespace Web.HtmlHelpers
{
    /// <summary>
    /// Класс содержащий различные эекстеншены для HtmlHelper'а
    /// </summary>
    public static class HtmlExtension
    {
        /// <summary>
        /// Кнопка отправки формы
        /// </summary>
        public static MvcHtmlString SubmitButton<TModel>(this HtmlHelper<TModel> html, string title)
        {
            var position = new TagBuilder("div");
            position.AddCssClass("col-md-offset-2");
            position.AddCssClass("col-md-10");
            var input = new TagBuilder("input");
            input.Attributes["type"] = "submit";
            input.Attributes["type"] = "submit";
            input.Attributes["value"] = title;
            input.AddCssClass("btn");
            input.AddCssClass("btn-default");
            position.InnerHtml = input.ToString(TagRenderMode.SelfClosing);
            return new MvcHtmlString(position.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Группа на форме
        /// </summary>
        public static FormGroup FormGroup<TModel>(this HtmlHelper<TModel> html)
        {
            var formGroup = new TagBuilder("div");
            formGroup.AddCssClass("form-group");
            return new FormGroup(formGroup);
        }

        /// <summary>
        /// Строго типизированый actionLink
        /// </summary>
        public static MvcHtmlString ActionLink<TController>(this HtmlHelper helper, string title,
            Expression<Func<TController, dynamic>> action, object routeValueDictionary, object htmlAttributes)
        {
            var methodCallExpression = action.Body as MethodCallExpression;
            if (methodCallExpression == null)
                throw new Exception("should be MethodCallExpression");
            return helper.ActionLink(title, methodCallExpression.Method.Name, ControllerNameByType(typeof(TController)), routeValueDictionary, htmlAttributes);
        }

        /// <summary>
        /// Получает имя свойства по типу модели
        /// </summary>
        public static MvcHtmlString GetPropertyName<TKeyModel>(this HtmlHelper model, Expression<Func<TKeyModel, object>> keySelector)
        {
            var methodCallExpression = keySelector.Body as MemberExpression;
            if (methodCallExpression == null)
                throw new Exception("Should be a property");
            return new MvcHtmlString(methodCallExpression.Member.Name);
        }

        /// <summary>
        /// todo:Избавится от дублирования кода, такой же код есть в базовом контроллере
        /// </summary>
        private static string ControllerNameByType(Type type)
        {
            var name = type.Name;
            return name.Substring(0, name.Length - "Controller".Length);
        }

        public static MvcHtmlString If(this HtmlHelper helper, bool flg, string value, string elseValue = "")
        {
            if(!flg)
                return new MvcHtmlString(elseValue);
            return new MvcHtmlString(value);
        }
    }



    public static class BootstapExtension
    {
        //todo:разработать или упереть откудато систему хелперов для работы с бутстрапом
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

        private static TagBuilder CreateIcon(string iconName)
        {
            var spanIcon = new TagBuilder("span");
            spanIcon.AddCssClass("glyphicon glyphicon-" + iconName);
            return spanIcon;
        }
    }
}