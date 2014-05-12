namespace Services.Security.SecurityActions
{
    /// <summary>
    /// �������� ������������ ��� ���������
    /// </summary>
    public enum MessageSecurityActions
    {
        /// <summary>
        /// ��������
        /// </summary>
        View,

        /// <summary>
        /// ���������
        /// </summary>
        Send,

        /// <summary>
        /// ������� ��������
        /// </summary>
        DeleteInput,

        /// <summary>
        /// ������� ���������
        /// </summary>
        DeleteOutput,

        /// <summary>
        /// �������� �� id
        /// </summary>
        GetById,

        /// <summary>
        /// �������� ������ ���������
        /// </summary>
        GetList
    }
}