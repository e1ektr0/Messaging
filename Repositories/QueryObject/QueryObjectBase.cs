using System.Collections.Generic;

namespace Repositories.QueryObject
{
    public abstract class QueryObjectBase
    {
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

        public List<ColumnConditional> SearchCoditionals { get; set; }

        public string Search { get; set; }
    }
}