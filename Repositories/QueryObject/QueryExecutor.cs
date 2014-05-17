using System.Collections.Generic;
using System.Linq;
using DataBaseModel;
using Shared.Mapper;

namespace Repositories.QueryObject
{
    /// <summary>
    /// Объект исполняющий запросы, опираясь на queryobject
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class QueryExecutor<TEntity> where TEntity : class
    {
        private readonly IContext<TEntity> _context;

        public QueryExecutor(IContext<TEntity> context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить коллекцию
        /// </summary>
        public IEnumerable<TEntity> Fecth(QueryObject<TEntity> queryObject)
        {
            return queryObject.Query(_context.Table).ToList();
        }

        /// <summary>
        /// Получить коллекцию и сконвертировать
        /// </summary>
        public IEnumerable<TModel> Fecth<TModel>(QueryObject<TEntity> queryObject) where TModel : new()
        {
            return queryObject.Query(_context.Table).ToList().Select(new TModel());
        }

        /// <summary>
        /// Общее колличество объектов
        /// </summary>
        public int Count(QueryObject<TEntity> queryObject)
        {
            return queryObject.TotalCount(_context.Table);
        }
    }
}