namespace Services.Security.SecurityActions
{
    /// <summary>
    /// Список действий безопасности по умолчанию
    /// </summary>
    public enum DefaultSecurityActions
    {
        /// <summary>
        /// Получить по id
        /// </summary>
        GetById, 

        /// <summary>
        /// Получить список объектов
        /// </summary>
        GetList, 
        
        /// <summary>
        /// Удалить
        /// </summary>
        Delete, 

        /// <summary>
        /// Обновить
        /// </summary>
        Update
    }
}