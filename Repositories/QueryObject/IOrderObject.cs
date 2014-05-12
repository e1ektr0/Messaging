using System.Linq;

namespace Repositories.QueryObject
{
    /// <summary>
    /// Интерфейс объекта сортировки, должен уметь сортировать IQueryable
    /// Требуется для строгой типизации дженериков exprssion tree т.е. ef опирается на них при выведении типов
    /// </summary>
    public interface IOrderObject<TEntity>
    {
        /// <summary>
        /// Сортировать asc
        /// </summary>
        IQueryable<TEntity> Order(IQueryable<TEntity> query);

        /// <summary>
        /// Сортировать по desc
        /// </summary>
        IQueryable<TEntity> OrderDesc(IQueryable<TEntity> query);
    }
}