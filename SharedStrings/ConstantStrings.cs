namespace SharedStrings
{
    /// <summary>
    /// Класс содержащий различные константы
    /// </summary>
    public static class ConstantStrings
    {
        public const string FormPropertyValue = "FormProperty";
        
        /// <summary>
        /// Валидатор имени пользователя
        /// </summary>
        public const string UserNameEmailRegex = "^[A-za-z]{3,15}$";

        public static class FormProperty
        {
            public const string Title = "Title";
            public const string Subtitle = "Subtitle";
            public const string Action = "Action";
            public const string SubmitButtonTitle = "SubmitButtonTitle";
            public const string Controller = "Controller";
        }
    }
}
