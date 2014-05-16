using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Repositories.QueryObject;

namespace Web.Models.ViewModel.Tables
{
    /// <summary>
    /// ������ ����������� �������
    /// </summary>
    public abstract class TablePageModel
    {

        #region Constructor & fields

        /// <summary>
        /// ��� ������
        /// </summary>
        private Type _type;
        
        /// <summary>
        /// ������ ������ ������
        /// </summary>
        protected List<Column> Columns;

        /// <summary>
        /// ������������� ���������� ��������
        /// </summary>
        protected TablePageModel()
        {
            IsGlobalSearch = true;
        }

        #endregion  Constructor & fields

        #region Properties

        /// <summary>
        /// ��������� �����
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        public string SubTitle { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// �������������� ���������� ����� ������
        /// </summary>
        /// <typeparam name="TItem">��� ������ - �� ���� ���������� ��������� ������� � �����</typeparam>
        public void Initialize<TItem>()
        {
            _type = typeof(TItem);
            IniColumns();
        }

        /// <summary>
        /// ������ ��������
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<object> GetItems();

        /// <summary>
        /// ������ �������, ������������ �� ������ � ��������� ������� �������
        /// </summary>
        public QueryObjectBase QueryObject { get; set; }

        /// <summary>
        /// ����� ���������� �����������
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// ���� ���������� ������� �� ����� �� ���� �������
        /// </summary>
        public bool IsGlobalSearch { get; set; }

        /// <summary>
        /// ���������� ������ �������� �� �������� ��������� ������
        /// </summary>
        public Paging GetPaing()
        {
            return new Paging(TotalCount, QueryObject.Count, QueryObject.Skip);
        }

        /// <summary>
        /// �������� �������� ���� �������
        /// </summary>
        public IEnumerable<Column> GetColumns()
        {
            return Columns;
        }


        /// <summary>
        /// �������������� ������� �� ��������� ����
        /// </summary>
        private void IniColumns()
        {
            Columns = new List<Column>();
            var properties = _type.GetProperties();
            var displayNameAttributes = properties.ToDictionary(n => n, n => n.GetCustomAttribute<DisplayNameAttribute>());
            Columns.AddRange(displayNameAttributes.Where(n => n.Value != null).Select(n => new Column(n.Key.Name, n.Value.DisplayName)));
        }

        #endregion Methods
    }
}