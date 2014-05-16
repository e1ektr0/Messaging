using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Extensions
{

     /// <summary>Defines extension methods for building and working with Expressions.</summary>
    public static class ExpressionExtensions
    {
        /// <summary>Ands the Expressions.</summary>
        /// <typeparam name="T">The target type of the Expression.</typeparam>
        /// <param name="expressions">The Expression(s) to and.</param>
        /// <returns>A new Expression.</returns>
        public static Expression<Func<T, bool>> And<T>(this IEnumerable<Expression<Func<T, bool>>> expressions)
        {
            var enumerable = expressions as Expression<Func<T, bool>>[] ?? expressions.ToArray();
            if (enumerable.IsNullOrEmpty())
                return null;

            Expression<Func<T, bool>> finalExpression = enumerable.First();

            foreach (Expression<Func<T, bool>> e in enumerable.Skip(1))
                finalExpression = finalExpression.And(e);

            return finalExpression;
        }

        /// <summary>Ors the Expressions.</summary>
        /// <typeparam name="T">The target type of the Expression.</typeparam>
        /// <param name="expressions">The Expression(s) to or.</param>
        /// <returns>A new Expression.</returns>
        public static Expression<Func<T, bool>> Or<T>(this IEnumerable<Expression<Func<T, bool>>> expressions)
        {
            var enumerable = expressions as Expression<Func<T, bool>>[] ?? expressions.ToArray();
            if (enumerable.IsNullOrEmpty())
                return null;

            var finalExpression = enumerable.First();

            return enumerable.Skip(1).Aggregate(finalExpression, (current, e) => current.Or(e));
        }

        /// <summary>Ands the Expression with the provided Expression.</summary>
        /// <typeparam name="T">The target type of the Expression.</typeparam>
        /// <param name="expression1">The left Expression to and.</param>
        /// <param name="expression2">The right Expression to and.</param>
        /// <returns>A new Expression.</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            //Reuse the first expression's parameter
            ParameterExpression param = expression1.Parameters.Single();
            Expression left = expression1.Body;
            Expression right = RebindParameter(expression2.Body, expression2.Parameters.Single(), param);
            BinaryExpression body = Expression.AndAlso(left, right);

            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        /// <summary>Ors the Expression with the provided Expression.</summary>
        /// <typeparam name="T">The target type of the Expression.</typeparam>
        /// <param name="expression1">The left Expression to or.</param>
        /// <param name="expression2">The right Expression to or.</param>
        /// <returns>A new Expression.</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            //Reuse the first expression's parameter
            ParameterExpression param = expression1.Parameters.Single();
            Expression left = expression1.Body;
            Expression right = RebindParameter(expression2.Body, expression2.Parameters.Single(), param);
            BinaryExpression body = Expression.OrElse(left, right);

            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        /// <summary>Updates the supplied expression using the appropriate parameter.</summary>
        /// <param name="expression">The expression to update.</param>
        /// <param name="oldParameter">The original parameter of the expression.</param>
        /// <param name="newParameter">The target parameter of the expression.</param>
        /// <returns>The updated expression.</returns>
        private static Expression RebindParameter(Expression expression, ParameterExpression oldParameter, ParameterExpression newParameter)
        {
            if (expression == null)
                return null;

            switch (expression.NodeType)
            {
                case ExpressionType.Parameter:
                {
                    var parameterExpression = (ParameterExpression)expression;

                    return (parameterExpression.Name == oldParameter.Name ? newParameter : parameterExpression);
                }
                case ExpressionType.MemberAccess:
                {
                    var memberExpression = (MemberExpression)expression;

                    return memberExpression.Update(RebindParameter(memberExpression.Expression, oldParameter, newParameter));
                }
                case ExpressionType.AndAlso:
                case ExpressionType.OrElse:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                {
                    var binaryExpression = (BinaryExpression)expression;

                    return binaryExpression.Update(RebindParameter(binaryExpression.Left, oldParameter, newParameter), binaryExpression.Conversion, RebindParameter(binaryExpression.Right, oldParameter, newParameter));
                }
                case ExpressionType.Call:
                {
                    var methodCallExpression = (MethodCallExpression)expression;

                    return methodCallExpression.Update(RebindParameter(methodCallExpression.Object, oldParameter, newParameter), methodCallExpression.Arguments.Select(arg => RebindParameter(arg, oldParameter, newParameter)));
                }
                case ExpressionType.Invoke:
                {
                    var invocationExpression = (InvocationExpression)expression;

                    return invocationExpression.Update(RebindParameter(invocationExpression.Expression, oldParameter, newParameter), invocationExpression.Arguments.Select(arg => RebindParameter(arg, oldParameter, newParameter)));
                }
                default:
                {
                    return expression;
                }
            }
        }

        public static Expression<Func<T, bool>> BuildContainsExpression<T, TR>(Expression<Func<T, TR>> valueSelector, IEnumerable<TR> values)
        {
            if (null == valueSelector)
                throw new ArgumentNullException("valueSelector");

            if (null == values)
                throw new ArgumentNullException("values");

            var parameterExpression = valueSelector.Parameters.Single();
            Expression aggregationExpression;

            var enumerable = values as TR[] ?? values.ToArray();
            if (!enumerable.IsNullOrEmpty())
                return (e => false);

            var equalExpressions = enumerable.Select(v => Expression.Equal(valueSelector.Body, Expression.Constant(v, typeof(TR))));
            aggregationExpression = equalExpressions.Aggregate<Expression>(Expression.Or);

            return Expression.Lambda<Func<T, bool>>(aggregationExpression, parameterExpression);
        }

        public static Expression<Func<T, bool>> BuildDoesNotContainExpression<T, TR>(Expression<Func<T, TR>> valueSelector, IEnumerable<TR> values)
        {
            if (null == valueSelector)
                throw new ArgumentNullException("valueSelector");

            var parameterExpression = valueSelector.Parameters.Single();

            var enumerable = values as TR[] ?? values.ToArray();
            if (!enumerable.IsNullOrEmpty())
                return (e => false);

            var notEqualExpressions = enumerable.Select(v => Expression.NotEqual(valueSelector.Body, Expression.Constant(v, typeof(TR))));
            var aggregationExpression = notEqualExpressions.Aggregate<Expression>(Expression.And);

            return Expression.Lambda<Func<T, bool>>(aggregationExpression, parameterExpression);
        }
    }
}

