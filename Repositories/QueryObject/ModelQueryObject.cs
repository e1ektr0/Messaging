using System;
using System.Linq;
using System.Linq.Expressions;
using Shared.Extensions;

namespace Repositories.QueryObject
{
    public abstract class ModelQueryObject<TModel, TEntity> : QueryObject<TEntity> where TModel : new()
    {
        protected void AddOrdering<TKeySelector>(Expression<Func<TModel, object>> keyExpression,
            Expression<Func<TEntity, TKeySelector>> orderExpression)
        {
            AddOrdering(GetPropertyKey(keyExpression), orderExpression);
        }

        protected bool HasConditional(Expression<Func<TModel, object>> keyExpression)
        {
            if (SearchCoditionals == null)
                return false;
            return SearchCoditionals.Any(n => n.Key == GetPropertyKey(keyExpression) && !n.Value.IsNullOrEmpty());
        }

        protected string GetConditional(Expression<Func<TModel, object>> keyExpression)
        {
            return SearchCoditionals.First(n => n.Key == GetPropertyKey(keyExpression)).Value;
        }


        private static string GetPropertyKey(Expression<Func<TModel, object>> keyExpression)
        {
            return new TModel().GetPropertyName(keyExpression);
        }
    }
}