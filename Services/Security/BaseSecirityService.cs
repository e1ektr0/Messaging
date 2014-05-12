using System;
using DomainEntities;
using Repositories;

namespace Services.Security
{
    /// <summary>
    /// Базовый сервис безосности
    /// </summary>
    /// <typeparam name="TSecurityObject">Объект безопасности</typeparam>
    /// <typeparam name="TAction">Тип действий безопасности</typeparam>
    /// <typeparam name="TKey">Тип ключа объекта</typeparam>
    public abstract class BaseSecirityService<TSecurityObject, TAction, TKey> : ISecurityService<TSecurityObject, TAction> where TSecurityObject : IKeyEntity<TKey>
    {
        private readonly IRepository<TSecurityObject, TKey> _repository;

        protected BaseSecirityService(IRepository<TSecurityObject, TKey> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Осуществить проверку безопасности
        /// </summary>
        public abstract void Check(TSecurityObject securityObject, TAction action);

        /// <summary>
        /// Осуществить проверку безопасности
        /// </summary>
        public void Check(TSecurityObject securityObject, TAction action, TKey id)
        {
            if (id == null || securityObject != null)
                Check(securityObject, action);

            Check(_repository.GetById(id), action);
        }

        /// <summary>
        /// Осуществить проверку безопасности
        /// </summary>
        public void Check(TSecurityObject securityObject, TAction action, object id)
        {
            //Если нет необходимости кастовать ключ
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


            //Проверяем, известен ли нам способ приведения
            //todo:при добавлении других типов расширить этот метод
            if ((typeof(TKey) != typeof(int)))
                throw new Exception("Cannot cast id in security service!");

            //Приводим object к int
            int idParsed;
            var result = int.TryParse((string)id, out idParsed);
            if (!result) idParsed = -1;
            Check(securityObject, action, (TKey)(object)idParsed);
        }

        /// <summary>
        /// Осуществить проверку безопасности
        /// </summary>
        public void Check(object securityObject, object action, object id)
        {
            Check((TSecurityObject)securityObject, (TAction)action, id);
        }
    }
}