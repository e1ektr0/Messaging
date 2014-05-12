namespace Services.Security.SecurityActions
{
    /// <summary>
    /// Действия безопасности для сообщений
    /// </summary>
    public enum MessageSecurityActions
    {
        /// <summary>
        /// Просмотр
        /// </summary>
        View,

        /// <summary>
        /// Отпрваить
        /// </summary>
        Send,

        /// <summary>
        /// Удалить входящее
        /// </summary>
        DeleteInput,

        /// <summary>
        /// Удалить изходящее
        /// </summary>
        DeleteOutput,

        /// <summary>
        /// Получить по id
        /// </summary>
        GetById,

        /// <summary>
        /// Получить список сообщений
        /// </summary>
        GetList
    }
}