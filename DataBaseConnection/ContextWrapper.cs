using System.Data.Entity;
using System.Linq;

namespace DataBaseModel
{
    /// <summary>
    /// Врапер для контекста
    /// </summary>
    public class ContextWrapper<T> : IContext<T> where T : class
    {
        private readonly Context _context;

        public ContextWrapper(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Доксту к сущности
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get { return _context.Set<T>(); }
        }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Обновить изменения к сущности
        /// </summary>
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Применить все изменения
        /// </summary>
        public void Comit()
        {
            _context.SaveChanges();
        }
    }
}
