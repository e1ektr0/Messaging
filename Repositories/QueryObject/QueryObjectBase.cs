using System.Collections.Generic;

namespace Repositories.QueryObject
{
    /// <summary>
    /// ��������� ��������� ���������, ��������, ����������, ����������
    /// </summary>
    public abstract class QueryObjectBase
    {
        /// <summary>
        /// �����������
        /// </summary>
        protected QueryObjectBase()
        {
            Count = 2;
        }

        /// <summary>
        /// ����������� ���������� �������
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// ����������� ����������� �������
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// ���� ������� �� ������� �������������� ����������
        /// </summary>
        public string SortingColumn { get; set; }

        /// <summary>
        /// ����������� ����������
        /// </summary>
        public SortingDirection SortingDirection { get; set; }

        /// <summary>
        /// ������ ����������� �� ��������
        /// </summary>
        public List<ColumnConditional> SearchCoditionals { get; set; }

        /// <summary>
        /// ���������� �����
        /// </summary>
        public string Search { get; set; }
    }
}