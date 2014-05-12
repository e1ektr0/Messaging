using Shared.Exceptions;

namespace Services.Exceptions
{
    /// <summary>
    /// Ошибка сервиса
    /// Пока не выделен слой валидации включает ошибки валидации на уровне сервисов
    /// </summary>
    public class ServiceException : BaseCustomException
    {
        public ServiceException(string message)
            : base(message)
        {
        }
    }
}