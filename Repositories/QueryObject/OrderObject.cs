using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.QueryObject
{
    /// <summary>
    /// ���������� ������� ����������
    /// </summary>
    public class OrderObject<TEntity, TKeyOrder> : IOrderObject<TEntity>
    {
        /// <summary>
        /// ��������� �� �������� ����������� ����������
        /// </summary>
        private readonly Expression<Func<TEntity, TKeyOrder>> _orderExpression;

        /// <summary>
        /// ����������� ������� ����������
        /// </summary>
        /// <param name="orderExpression">���������, �� �������� ����� �������������� ����� ���� ��� ����������</param>
        public OrderObject(Expression<Func<TEntity, TKeyOrder>> orderExpression)
        {
            _orderExpression = orderExpression;
        }

        #region IOrderObject<TEntity>

        /// <summary>
        /// ����������� �� asc
        /// </summary>
        public IQueryable<TEntity> Order(IQueryable<TEntity> query)
        {
            return query.OrderBy(_orderExpression);
        }

        /// <summary>
        /// ����������� �� desc
        /// </summary>
        public IQueryable<TEntity> OrderDesc(IQueryable<TEntity> query)
        {
            return query.OrderByDescending(_orderExpression);
        }

	    #endregion IOrderObject<TEntity>
    }
}