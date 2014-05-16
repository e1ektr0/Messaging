using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repositories.QueryObject;
using Shared.Extensions;

namespace Web.Models.ViewModel.Tables
{
    /// <summary>
    /// ������ ������������ ��������� ������� �� ������������ ajax
    /// </summary>
    /// <typeparam name="TModelRow">������ ������</typeparam>
    public class NotAjaxTable<TModelRow> : TablePageModel where TModelRow : new()
    {
        /// <summary>
        /// �����������. �������������� ������� ������
        /// </summary>
        /// <param name="queryObject">������ ����������� ��������� ��������� � ������ ����������</param>
        public NotAjaxTable(QueryObjectBase queryObject)
        {
            QueryObject = queryObject;
            Initialize<TModelRow>();
        }

        /// <summary>
        /// ������ �������� �� ������� ��������
        /// </summary>
        public List<TModelRow> PageItems { get; set; }

        /// <summary>
        /// ���������� ������ ��������
        /// </summary>
        public override IEnumerable<object> GetItems()
        {
            return PageItems.Select(n => (object)n);
        }

        /// <summary>
        /// �������� ������� �� ���� ��������
        /// </summary>
        public void FilterAll()
        {
            Columns.ForEach(n => n.IsFiltered = true);
        }

        /// <summary>
        /// �������� ������ ��� ��������� �������
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