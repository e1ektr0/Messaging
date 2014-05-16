namespace Web.Models.ViewModel.Tables
{
    /// <summary>
    /// Описывает колонку в таблице
    /// </summary>
    public class Column
    {

        /// <summary>
        /// Созадёт описание котолонки
        /// </summary>
        /// <param name="key">Ключь для связывания viewModel</param>
        /// <param name="displayName">Заголовок колонки</param>
        public Column(string key, string displayName)
        {
            Key = key;
            Title = displayName;
        }

        /// <summary>
        /// Ключ для связывания ui с бэкенд моделью
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Заголовок колонки
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Нужно ли рендерить фильтр по этой колонке
        /// </summary>
        public bool IsFiltered { get; set; }
    }
}