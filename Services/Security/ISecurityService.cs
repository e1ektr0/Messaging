namespace Services.Security
{
    /// <summary>
    /// Интерфейс для сервиса безопасности
    /// </summary>
    /// <typeparam name="TSecurityObject">Объект безопасности</typeparam>
    /// <typeparam name="TSecurityAction">Тип дейсвия безопасности</typeparam>
    public interface ISecurityService<in TSecurityObject, in TSecurityAction>
    {
        /// <summary>
        /// Проверить доcтуп
        /// </summary>
        void Check(TSecurityObject securityObject, TSecurityAction action, object id);
        
        /// <summary>
        /// Проверить доcтуп
        /// </summary>
        void Check(TSecurityObject securityObject, TSecurityAction action);

        /// <summary>
        /// Проверить доcтуп
        /// </summary>
        void Check(object securityObject, object action, object id);
    }
}