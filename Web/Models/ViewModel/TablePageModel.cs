using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

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
    }

    public class NotAjaxTable<TItem> : TablePageModel
    {
        public NotAjaxTable()
        {
            Initialize<TItem>();
        }

        public List<TItem> PageItems { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public override IEnumerable<object> GetItems()
        {
            return PageItems.Select(n => (object)n);
        }
    }
}