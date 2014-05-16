using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Extensions
{
    /// <summary>
    /// Класс содержащий методы расширения на System.Object
    /// </summary>
    public static class SystemObjectExtension
    {
        /// <summary>
        /// Получает значение поля безопастно
        /// Если объект источник null вернёт null
        /// </summary>
        public static TProperty GetSafety<TE, TProperty>(this TE obj, Func<TE, TProperty> func) where TE : class where TProperty : class 
        {
            return obj != null ? func(obj) : null;
        }

        /// <summary>
        /// Строковое представление имени поля
        /// </summary>
        public static string GetPropertyName<TKeyModel>(this TKeyModel model, Expression<Func<TKeyModel, object>> keySelector)
        {
            var methodCallExpression = keySelector.Body as MemberExpression;
            if (methodCallExpression == null)
                throw new Exception("Should be a property");
            return methodCallExpression.Member.Name;
        }

        //todo:В отдельный файл экстеншена
        public static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> collection)
        {
            return (collection == null || !collection.Any());
        }
    }
}