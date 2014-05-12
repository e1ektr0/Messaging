using System.Collections.Generic;
using DomainEntities;
using Repositories.QueryObject;

namespace Repositories
{
    /// <summary>
    /// ��������� ����������� ���������
    /// </summary>
    public interface IMessagesRepository : IRepository<Message, int>
    {
        /// <summary>
        /// �������� �������� ��������� �������� ������������
        /// </summary>
        IEnumerable<Message> GetInput(QueryObject<Message> queryObject);

        /// <summary>
        /// �������� ��������� ��������� �������� ������������
        /// </summary>
        IEnumerable<Message> GetOutput(QueryObject<Message> queryObject);
    }
}