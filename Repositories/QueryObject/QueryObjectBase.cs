using System.Collections.Generic;

namespace Repositories.QueryObject
{
    public abstract class QueryObjectBase
    {
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

        public List<ColumnConditional> SearchCoditionals { get; set; }

        public string Search { get; set; }
    }
}