namespace Repositories.QueryObject
{
    /// <summary>
    /// Ограничение на колонку
    /// Используется для передачи фильтров с UI
    /// </summary>
    public class ColumnConditional
    {
        /// <summary>
        /// Ключь поля
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Значение ограничения
        /// </summary>
        public string Value { get; set; }
    }
}