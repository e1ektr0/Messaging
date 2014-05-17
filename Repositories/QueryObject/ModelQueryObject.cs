using System;
using System.Linq;
using System.Linq.Expressions;
using Shared.Extensions;

namespace Repositories.QueryObject
{
    /// <summary>
    /// Базовый объект связывания модели представления и объекта запроса
    /// </summary>
    public abstract class ModelQueryObject<TModel, TEntity> : QueryObject<TEntity> where TModel : new()
    {
        /// <summary>
        /// Добавляет сортировку по ключу модели
        /// </summary>
        protected void AddOrdering<TKeySelector>(Expression<Func<TModel, object>> keyExpression,
            Expression<Func<TEntity, TKeySelector>> orderExpression)
        {
            AddOrdering(GetPropertyKey(keyExpression), orderExpression);
        }

        /// <summary>
        /// Проверяет введённ ли кондишен на конкретное поле
        /// </summary>
        protected bool HasConditional(Expression<Func<TModel, object>> keyExpression)
        {
            if (SearchCoditionals == null)
                return false;
            return SearchCoditionals.Any(n => n.Key == GetPropertyKey(keyExpression) && !n.Value.IsNullOrEmpty());
        }

        /// <summary>
        /// Получить ограничение по ключу модели
        /// </summary>
        protected string GetConditional(Expression<Func<TModel, object>> keyExpression)
        {
            return SearchCoditionals.First(n => n.Key == GetPropertyKey(keyExpression)).Value;
        }

        /// <summary>
        /// Получить строковое представления по экспрешену модели
        /// </summary>
        private static string GetPropertyKey(Expression<Func<TModel, object>> keyExpression)
        {
            return new TModel().GetPropertyName(keyExpression);
        }
    }
}