using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shared.Extensions;

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

    /// <summary>
    /// Базовый объект запроса
    /// Хранит информацию о пейдженге, сортировке
    /// todo:По мере необходимости добавить информацию о поиске
    /// </summary>
    public abstract class QueryObject<TEntity> : QueryObjectBase
    {
        #region Properties

        /// <summary>
        /// Словарь связываения ключа сортировки с объектом сортровки
        /// Необходим для связываения полей DTO/ViewModel с сортировкой
        /// todo:при расширении по аналогии добавить словарь связывания поиска по колонкам
        /// </summary>
        public readonly IDictionary<string, IOrderObject<TEntity>> OrderDictionary = new Dictionary<string, IOrderObject<TEntity>>();

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Осуществляет поиск, пейджинг и сортировку
        /// </summary>
        public IQueryable<TEntity> Query(IQueryable<TEntity> query)
        {
            return Paging(Order(query.Where(Filter().GetExpression())));
        }

        public int TotalCount(IQueryable<TEntity> query)
        {
            return query.Where(Filter().GetExpression()).Count();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Сортировка
        /// </summary>
        private IQueryable<TEntity> Order(IQueryable<TEntity> query)
        {
            if (SortingColumn == null || !OrderDictionary.ContainsKey(SortingColumn))
            {
                SortingDirection = SortingDirection.None;
            }

            if (SortingColumn == null || !OrderDictionary.ContainsKey(SortingColumn))
                SortingColumn = OrderDictionary.First().Key;

            var orderObject = OrderDictionary[SortingColumn];
            if (SortingDirection != SortingDirection.Desc)
                return orderObject.Order(query);
            return orderObject.OrderDesc(query);
        }

        /// <summary>
        /// Пейджинг
        /// </summary>
        private IQueryable<TEntity> Paging(IQueryable<TEntity> query)
        {
            return query.Skip(Skip).Take(Count);
        }

        /// <summary>
        /// Добавляет связь ключа вьюхи с выборкой сортировки
        /// </summary>
        protected void AddOrdering<TKeySelector>(string key, Expression<Func<TEntity, TKeySelector>> orderExpression)
        {
            OrderDictionary.Add(key, new OrderObject<TEntity, TKeySelector>(orderExpression));
        }

        protected virtual Conditional<TEntity> Filter()
        {
            return new Conditional<TEntity>(true);
        }

        #endregion Private Methods
    }

    public class Conditional<TEntity>
    {
        private Expression<Func<TEntity, bool>> _expression;
        public Conditional(bool @default)
        {
            _expression = n => @default;
        }

        public void And(Expression<Func<TEntity, bool>> expression)
        {
            _expression = _expression.And(expression);
        }
        public void And(Conditional<TEntity> conditional)
        {
            _expression = _expression.And(conditional.GetExpression());
        }

        public Expression<Func<TEntity, bool>> GetExpression()
        {
            return _expression;
        }

        public void Or(Expression<Func<TEntity, bool>> expression)
        {
            _expression = _expression.Or(expression);
        }


    }

    public class ColumnConditional
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}