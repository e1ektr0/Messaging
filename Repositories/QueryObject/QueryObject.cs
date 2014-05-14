using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.QueryObject
{
    public abstract class QueryObjectBase
    {
        protected QueryObjectBase()
        {
            PageSize = 2;
        }

        public int PageSize { get; set; }

        /// <summary>
        /// ����������� ����������� �������
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// ����������� ����������� �������
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// ���� ������� �� ������� �������������� ����������
        /// </summary>
        public string SortingColumn { get; set; }

        public List<ColumnConditional> SearchCoditionals { get; set; }

        public string Search { get; set; }
    }

    /// <summary>
    /// ������� ������ �������
    /// ������ ���������� � ���������, ����������
    /// todo:�� ���� ������������� �������� ���������� � ������
    /// </summary>
    public abstract class QueryObject<TEntity> : QueryObjectBase
    {
        #region Properties

        /// <summary>
        /// ����������� ����������
        /// </summary>
        public SortingDirection SortingDirection { get; set; }

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
            return Paging(Order(query));
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// ����������
        /// </summary>
        private IQueryable<TEntity> Order(IQueryable<TEntity> query)
        {
            if (SortingDirection == SortingDirection.Asc)
                return OrderDictionary[SortingColumn].Order(query);
            return OrderDictionary[SortingColumn].OrderDesc(query);
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

        #endregion Private Methods
    }


    public class ColumnConditional
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}