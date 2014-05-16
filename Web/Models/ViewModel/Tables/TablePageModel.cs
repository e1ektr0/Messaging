using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Repositories.QueryObject;
using Shared.Extensions;

namespace Web.Models.ViewModel
{
    public abstract class TablePageModel
    {
        protected List<Column> Columns;
        private Type _type;

        protected TablePageModel()
        {
            GlobalSearch = true;
        }

        private void IniColumns()
        {
            Columns = new List<Column>();
            var properties = _type.GetProperties();
            var displayNameAttributes = properties.ToDictionary(n => n, n => n.GetCustomAttribute<DisplayNameAttribute>());
            Columns.AddRange(displayNameAttributes.Where(n => n.Value != null).Select(n => new Column(n.Key.Name, n.Value.DisplayName)));
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Sourse { get; set; }

        public void Initialize<TItem>()
        {
            _type = typeof(TItem);
            IniColumns();
        }

        public abstract IEnumerable<object> GetItems();

        public QueryObjectBase QueryObject { get; set; }

        public int TotalCount { get; set; }
        public bool GlobalSearch { get; set; }

        public Paging GetPaing()
        {
            return new Paging(TotalCount, QueryObject.Count, QueryObject.Skip);
        }

        public IEnumerable<Column> GetColumns()
        {
            return Columns;
        }

    }

    public class Paging
    {
        private readonly int _pageSize;
        private const int WindowsSize = 5;

        public Paging(int totalCount, int pageSize, int skip)
        {
            _pageSize = pageSize;
            var totalPagesDouble = (double)totalCount / pageSize;
            var totalPage = (int)totalPagesDouble;
            if (totalPagesDouble - (int)totalPagesDouble > 0)
            {
                totalPage += 1;
            }
            CurrentPage = skip / pageSize;
            TotalPages = totalPage;

            if (CurrentPage > WindowsSize)
                Start = CurrentPage - WindowsSize / 2;
            else
                Start = 0;
            if (totalPage - CurrentPage - 1 > WindowsSize)
                End = CurrentPage + WindowsSize / 2;
            else
                End = totalPage - 1;
        }

        public int TotalPages { get; set; }

        public int Start { get; set; }

        public int End { get; set; }

        public int CurrentPage { get; set; }

        public int SkipConvert(int page)
        {
            return page * _pageSize;
        }
    }

    public class NotAjaxTable<TModel> : TablePageModel where TModel : new()
    {
        public NotAjaxTable(QueryObjectBase queryObject)
        {
            QueryObject = queryObject;
            Initialize<TModel>();
        }

        public List<TModel> PageItems { get; set; }

        public override IEnumerable<object> GetItems()
        {
            return PageItems.Select(n => (object)n);
        }


        public void FilterAll()
        {
            Columns.ForEach(n => n.IsFiltered = true);
        }
       
        public void Filter(Expression<Func<TModel, object>> keyExpression)
        {
            var propertyName = new TModel().GetPropertyName(keyExpression);

            Columns.Where(n => n.Key == propertyName)
                .ToList()
                .ForEach(n => n.IsFiltered = true);
        }
    }
}