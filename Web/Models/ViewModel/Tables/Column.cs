namespace Web.Models.ViewModel.Tables
{
    /// <summary>
    /// ��������� ������� � �������
    /// </summary>
    public class Column
    {

        /// <summary>
        /// ������ �������� ���������
        /// </summary>
        /// <param name="key">����� ��� ���������� viewModel</param>
        /// <param name="displayName">��������� �������</param>
        public Column(string key, string displayName)
        {
            Key = key;
            Title = displayName;
        }

        /// <summary>
        /// ���� ��� ���������� ui � ������ �������
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// ��������� �������
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// ����� �� ��������� ������ �� ���� �������
        /// </summary>
        public bool IsFiltered { get; set; }
    }
}