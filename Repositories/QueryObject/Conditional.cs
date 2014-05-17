using System;
using System.Linq.Expressions;
using Shared.Extensions;

namespace Repositories.QueryObject
{
    /// <summary>
    /// ������ ����������� 
    /// �������� ��������� ����������� �����������
    /// </summary>
    public class Conditional<TEntity>
    {
        private Expression<Func<TEntity, bool>> _expression;

        public Conditional(bool @default)
        {
            _expression = n => @default;
        }

        /// <summary>
        /// �������� ���������
        /// </summary>
        public void And(Expression<Func<TEntity, bool>> expression)
        {
            _expression = _expression.And(expression);
        }


        /// <summary>
        /// �������� �����������
        /// </summary>
        public void And(Conditional<TEntity> conditional)
        {
            _expression = _expression.And(conditional.GetExpression());
        }

        /// <summary>
        /// �������� ���������
        /// </summary>
        public Expression<Func<TEntity, bool>> GetExpression()
        {
            return _expression;
        }

        /// <summary>
        /// �������� ��������� ����� ���
        /// </summary>
        public void Or(Expression<Func<TEntity, bool>> expression)
        {
            _expression = _expression.Or(expression);
        }
    }
}