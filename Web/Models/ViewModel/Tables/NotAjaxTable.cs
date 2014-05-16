using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repositories.QueryObject;
using Shared.Extensions;

namespace Web.Models.ViewModel.Tables
{
    /// <summary>
    /// Можель описывающиая рендеринг таблицы не использующей ajax
    /// </summary>
    /// <typeparam name="TModelRow">Модель строки</typeparam>
    public class NotAjaxTable<TModelRow> : TablePageModel where TModelRow : new()
    {
        /// <summary>
        /// Конструктор. Инициализирует базовую модель
        /// </summary>
        /// <param name="queryObject">Объект описывающий состояние навигации и услоия фильтрации</param>
        public NotAjaxTable(QueryObjectBase queryObject)
        {
            QueryObject = queryObject;
            Initialize<TModelRow>();
        }

        /// <summary>
        /// Список объектов на текущей странице
        /// </summary>
        public List<TModelRow> PageItems { get; set; }

        /// <summary>
        /// Возвращаем список объектов
        /// </summary>
        public override IEnumerable<object> GetItems()
        {
            return PageItems.Select(n => (object)n);
        }

        /// <summary>
        /// Включить фильтры по всем колонкам
        /// </summary>
        public void FilterAll()
        {
            Columns.ForEach(n => n.IsFiltered = true);
        }

        /// <summary>
        /// Включить фильтр для отдельной колонки
        /// </summary>
        public void Filter(Expression<Func<TModelRow, object>> keyExpression)
        {
            var propertyName = new TModelRow().GetPropertyName(keyExpression);

            Columns.Where(n => n.Key == propertyName)
                .ToList()
                .ForEach(n => n.IsFiltered = true);
        }
    }
}