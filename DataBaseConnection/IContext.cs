using System.Linq;

namespace DataBaseModel
{
    /// <summary>
    /// Контекст для одной сущности
    /// </summary>
    public interface IContext<T> where T : class
    {
        /// <summary>
        /// Доксту к сущности
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        void Delete(T entity);

        /// <summary>
        /// Применить изменения к сущности
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Применить все изменения
        /// </summary>
        void Comit();
    }
}