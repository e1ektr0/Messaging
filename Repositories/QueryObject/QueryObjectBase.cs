using System.Collections.Generic;

namespace Repositories.QueryObject
{
    /// <summary>
    /// Описывает состояние навигации, пейджинг, сортировку, фильтрацию
    /// </summary>
    public abstract class QueryObjectBase
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        protected QueryObjectBase()
        {
            Count = 2;
        }

        /// <summary>
        /// Колличество пропущеных записей
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Колличество запрошенных записей
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Ключ колонки по которой осуществляется сортировка
        /// </summary>
        public string SortingColumn { get; set; }

        /// <summary>
        /// Направление сортировки
        /// </summary>
        public SortingDirection SortingDirection { get; set; }

        /// <summary>
        /// Список ограничений по колонкам
        /// </summary>
        public List<ColumnConditional> SearchCoditionals { get; set; }

        /// <summary>
        /// Глобальный поиск
        /// </summary>
        public string Search { get; set; }
    }
}