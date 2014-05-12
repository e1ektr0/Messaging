using System;
using DomainEntities;
using Repositories;

namespace Services.Security
{
    /// <summary>
    /// ������� ������ ����������
    /// </summary>
    /// <typeparam name="TSecurityObject">������ ������������</typeparam>
    /// <typeparam name="TAction">��� �������� ������������</typeparam>
    /// <typeparam name="TKey">��� ����� �������</typeparam>
    public abstract class BaseSecirityService<TSecurityObject, TAction, TKey> : ISecurityService<TSecurityObject, TAction> where TSecurityObject : IKeyEntity<TKey>
    {
        private readonly IRepository<TSecurityObject, TKey> _repository;

        protected BaseSecirityService(IRepository<TSecurityObject, TKey> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// ����������� �������� ������������
        /// </summary>
        public abstract void Check(TSecurityObject securityObject, TAction action);

        /// <summary>
        /// ����������� �������� ������������
        /// </summary>
        public void Check(TSecurityObject securityObject, TAction action, TKey id)
        {
            if (id == null || securityObject != null)
                Check(securityObject, action);

            Check(_repository.GetById(id), action);
        }

        /// <summary>
        /// ����������� �������� ������������
        /// </summary>
        public void Check(TSecurityObject securityObject, TAction action, object id)
        {
            //���� ��� ������������� ��������� ����
            if (id is TKey)
            {
                Check(securityObject, action, (TKey)id);
                return;
            }
            if (id == null && !typeof (TKey).IsValueType)
            {
                Check(securityObject, action);
                return;
            }


            //���������, �������� �� ��� ������ ����������
            //todo:��� ���������� ������ ����� ��������� ���� �����
            if ((typeof(TKey) != typeof(int)))
                throw new Exception("Cannot cast id in security service!");

            //�������� object � int
            int idParsed;
            var result = int.TryParse((string)id, out idParsed);
            if (!result) idParsed = -1;
            Check(securityObject, action, (TKey)(object)idParsed);
        }

        /// <summary>
        /// ����������� �������� ������������
        /// </summary>
        public void Check(object securityObject, object action, object id)
        {
            Check((TSecurityObject)securityObject, (TAction)action, id);
        }
    }
}