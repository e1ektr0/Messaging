using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.QueryObject
{
    /// <summary>
    /// Реализация объекта сортировки
    /// </summary>
    public class OrderObject<TEntity, TKeyOrder> : IOrderObject<TEntity>
    {
        /// <summary>
        /// Выражение по которому производить сортировку
        /// </summary>
        private readonly Expression<Func<TEntity, TKeyOrder>> _orderExpression;

        /// <summary>
        /// Конструктор объекта сортировки
        /// </summary>
        /// <param name="orderExpression">Выражение, по которому будет осуществляться выбор поля для сортировки</param>
        public OrderObject(Expression<Func<TEntity, TKeyOrder>> orderExpression)
        {
            _orderExpression = orderExpression;
        }

        #region IOrderObject<TEntity>

        /// <summary>
        /// Сортировать по asc
        /// </summary>
        public IQueryable<TEntity> Order(IQueryable<TEntity> query)
        {
            return query.OrderBy(_orderExpression);
        }

        /// <summary>
        /// Сортировать по desc
        /// </summary>
        public IQueryable<TEntity> OrderDesc(IQueryable<TEntity> query)
        {
            return query.OrderByDescending(_orderExpression);
        }

	    #endregion IOrderObject<TEntity>
    }
}