namespace Web.Models.ViewModel.Tables
{
    /// <summary>
    /// ������ ��������
    /// </summary>
    public class Paging
    {
        private readonly int _pageSize;
        private const int WindowsSize = 5;

        /// <summary>
        /// ����������� � ����� �������� ���������� � ����� ����������� �������
        /// </summary>
        public Paging(int totalCount, int pageSize, int skip)
        {
            _pageSize = pageSize;
            var totalPagesDouble = (double)totalCount / pageSize;
            var totalPage = (int)totalPagesDouble;
            if (totalPagesDouble - (int)totalPagesDouble > 0)
            {
                totalPage += 1;
            }
            CurrentPage = skip / pageSize;
            TotalPages = totalPage;

            //����������� � ������ �� ����� ����� ���������� ����������(� ������ ����)
            if (CurrentPage > WindowsSize)
                Start = CurrentPage - WindowsSize / 2;
            else
                Start = 0;
            if (totalPage - CurrentPage - 1 > WindowsSize)
                End = CurrentPage + WindowsSize / 2;
            else
                End = totalPage - 1;
        }

        /// <summary>
        /// ����� ���������� �������
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// �������� � ������� ���������� ��������
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// �������� �� ������� ���������� ��������
        /// </summary>
        public int End { get; set; }

        /// <summary>
        /// ������� ������������ ��������
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// ������������ ����� �������� � ���������� �������� ������� ���������� ����������
        /// </summary>
        public int SkipConvert(int page)
        {
            return page * _pageSize;
        }
    }
}