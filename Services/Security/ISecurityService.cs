namespace Services.Security
{
    /// <summary>
    /// ��������� ��� ������� ������������
    /// </summary>
    /// <typeparam name="TSecurityObject">������ ������������</typeparam>
    /// <typeparam name="TSecurityAction">��� ������� ������������</typeparam>
    public interface ISecurityService<in TSecurityObject, in TSecurityAction>
    {
        /// <summary>
        /// ��������� ��c���
        /// </summary>
        void Check(TSecurityObject securityObject, TSecurityAction action, object id);
        
        /// <summary>
        /// ��������� ��c���
        /// </summary>
        void Check(TSecurityObject securityObject, TSecurityAction action);

        /// <summary>
        /// ��������� ��c���
        /// </summary>
        void Check(object securityObject, object action, object id);
    }
}