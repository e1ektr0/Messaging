using System.Linq;

namespace Repositories.QueryObject
{
    /// <summary>
    /// ��������� ������� ����������, ������ ����� ����������� IQueryable
    /// ��������� ��� ������� ��������� ���������� exprssion tree �.�. ef ��������� �� ��� ��� ��������� �����
    /// </summary>
    public interface IOrderObject<TEntity>
    {
        /// <summary>
        /// ����������� asc
        /// </summary>
        IQueryable<TEntity> Order(IQueryable<TEntity> query);

        /// <summary>
        /// ����������� �� desc
        /// </summary>
        IQueryable<TEntity> OrderDesc(IQueryable<TEntity> query);
    }
}