using Shared.Exceptions;

namespace Services.Exceptions
{
    /// <summary>
    /// Ошибка безопасности
    /// </summary>
    public class SecurityException : BaseCustomException
    {
        public SecurityException(string message) : base(message)
        {

        }
    }
}