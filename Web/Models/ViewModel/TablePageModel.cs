using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Repositories.QueryObject;

namespace Web.Models.ViewModel
{
    public abstract class TablePageModel
    {
        private Type _type;

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Sourse { get; set; }

        public void Initialize<TItem>()
        {
            _type = typeof(TItem);
        }

        public IEnumerable<Column> GetColumns()
        {
            var properties = _type.GetProperties();
            var displayNameAttributes = properties.ToDictionary(n => n, n => n.GetCustomAttribute<DisplayNameAttribute>());
            return displayNameAttributes.Where(n => n.Value != null).Select(n => new Column(n.Value.DisplayName));
        }

        public abstract IEnumerable<object> GetItems();

        public QueryObjectBase QueryObject { get; set; }

        public int TotalCount { get; set; }

        public Paging GetPaing()
        {
            return new Paging(TotalCount, QueryObject.PageSize, QueryObject.Skip);
        }
    }

    public class Paging
    {
        private const int WindowsSize = 5;

        public Paging(int totalCount, int pageSize, int skip)
        {
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
            if (totalPage - CurrentPage < WindowsSize)
                End = CurrentPage + WindowsSize / 2;
        }

        public int TotalPages { get; set; }

        public int Start { get; set; }

        public int End { get; set; }

        public int CurrentPage { get; set; }
    }

    public class NotAjaxTable<TItem> : TablePageModel
    {
        public NotAjaxTable(QueryObjectBase queryObject)
        {
            QueryObject = queryObject;
            Initialize<TItem>();
        }

        public List<TItem> PageItems { get; set; }

        public override IEnumerable<object> GetItems()
        {
            return PageItems.Select(n => (object)n);
        }
    }
}