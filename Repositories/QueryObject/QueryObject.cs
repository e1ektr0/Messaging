using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.QueryObject
{
    /// <summary>
    /// ������� ������ �������
    /// ������ ���������� � ���������, ����������
    /// </summary>
    public abstract class QueryObject<TEntity> : QueryObjectBase
    {
        #region Properties

        /// <summary>
        /// ������� ����������� ����� ���������� � �������� ���������
        /// ��������� ��� ����������� ����� DTO/ViewModel � �����������
        /// todo:��� ���������� �� �������� �������� ������� ���������� ������ �� ��������
        /// </summary>
        public readonly IDictionary<string, IOrderObject<TEntity>> OrderDictionary = new Dictionary<string, IOrderObject<TEntity>>();

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// ������������ �����, �������� � ����������
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
        /// ����������
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
        /// ��������
        /// </summary>
        private IQueryable<TEntity> Paging(IQueryable<TEntity> query)
        {
            return query.Skip(Skip).Take(Count);
        }

        /// <summary>
        /// ��������� ����� ����� ����� � �������� ����������
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
}