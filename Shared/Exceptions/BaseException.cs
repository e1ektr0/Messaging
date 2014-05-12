using System;

namespace Shared.Exceptions
{
    /// <summary>
    /// Базовый класс кастомных ошибок
    /// Это различные ошибки слоя бизнес логики, которые должны быть обработаны контроллерами
    /// </summary>
    public abstract class BaseCustomException : Exception
    {
        protected BaseCustomException(string message)
            : base(message ?? "")
        {
        }
    }
}
