namespace Web.Views
{
    /// <summary>
    /// Список базовых шаблонов
    /// </summary>
    public static class Default
    {
        /// <summary>
        /// Шаблон формы редактирования
        /// </summary>
        public const string Edit = "~/Views/Default/Edit.cshtml";

        /// <summary>
        /// Шаблон формы отображения таблицы
        /// </summary>
        public const string Table = "~/Views/Default/Table.cshtml";
    }

    /// <summary>
    /// Список вьюх для работы с системой сообщенйи
    /// </summary>
    public static class Messaging
    {
        /// <summary>
        /// Шаблон списка сообщенйи
        /// </summary>
        public const string MessageList = "~/Views/Messaging/_MessageList.cshtml";

        /// <summary>
        /// Шаблон просмотра сообщений
        /// </summary>
        public const string MessageRead = "~/Views/Messaging/_MessageRead.cshtml";

        /// <summary>
        /// Шаблон написания сообщений
        /// </summary>
        public const string MessageWrite = "~/Views/Messaging/_MessageWrite.cshtml";

        /// <summary>
        /// Список пользователей
        /// </summary>
        public const string UsersList = "~/Views/Messaging/_UsersList.cshtml";


        /// <summary>
        /// Базовая страница системы сообщений
        /// </summary>
        public const string Main = "~/Views/Messaging/StartPage.cshtml";
    }

    /// <summary>
    /// Сипсок вьюх приветсвия
    /// </summary>
    public static class Home
    {
        /// <summary>
        /// Вьюха для описания нашего проекта
        /// </summary>
        public const string ReadMe = "~/Views/Home/ReadMe.cshtml";
    }
}