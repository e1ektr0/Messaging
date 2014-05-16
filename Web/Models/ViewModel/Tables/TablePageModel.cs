using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Repositories.QueryObject;

namespace Web.Models.ViewModel.Tables
{
    /// <summary>
    /// Модель описывающая таблицу
    /// </summary>
    public abstract class TablePageModel
    {

        #region Constructor & fields

        /// <summary>
        /// Тип строки
        /// </summary>
        private Type _type;
        
        /// <summary>
        /// Список колонк талици
        /// </summary>
        protected List<Column> Columns;

        /// <summary>
        /// Устанавливает дефоултные значения
        /// </summary>
        protected TablePageModel()
        {
            IsGlobalSearch = true;
        }

        #endregion  Constructor & fields

        #region Properties

        /// <summary>
        /// Заголовок формы
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Подзаголовок
        /// </summary>
        public string SubTitle { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Инициализирует конкретным типом строки
        /// </summary>
        /// <typeparam name="TItem">Тип строки - по нему происходит генерация колонок и строк</typeparam>
        public void Initialize<TItem>()
        {
            _type = typeof(TItem);
            IniColumns();
        }

        /// <summary>
        /// Списко объектов
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<object> GetItems();

        /// <summary>
        /// Объект запроса, отправляется на сервер и описывает текущию выборку
        /// </summary>
        public QueryObjectBase QueryObject { get; set; }

        /// <summary>
        /// Общее колличесво результатов
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Флаг отражающий включён ли поиск по всем строкам
        /// </summary>
        public bool IsGlobalSearch { get; set; }

        /// <summary>
        /// Генерирует объект пейджинг по текущему состоянию модели
        /// </summary>
        public Paging GetPaing()
        {
            return new Paging(TotalCount, QueryObject.Count, QueryObject.Skip);
        }

        /// <summary>
        /// Получает описание всех колонок
        /// </summary>
        public IEnumerable<Column> GetColumns()
        {
            return Columns;
        }


        /// <summary>
        /// Инициализирует колокни по указаному типу
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