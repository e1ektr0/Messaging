using System.Collections.Generic;
using System.Linq;
using DataBaseModel;
using Shared.Mapper;

namespace Repositories.QueryObject
{
    public class QueryExecutor<TEntity> where TEntity : class
    {
        private readonly IContext<TEntity> _context;

        public QueryExecutor(IContext<TEntity> context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> Fecth(QueryObject<TEntity> queryObject)
        {
            return queryObject.Query(_context.Table).ToList();
        }

        public IEnumerable<TModel> Fecth<TModel>(QueryObject<TEntity> queryObject) where TModel : new()
        {
            return queryObject.Query(_context.Table).ToList().Select(new TModel());
        }

        public int Count(QueryObject<TEntity> queryObject)
        {
            return queryObject.TotalCount(_context.Table);
        }
    }
}