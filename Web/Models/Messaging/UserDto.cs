namespace Web.Models.Messaging
{
    /// <summary>
    /// Объект dto пользователя
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}