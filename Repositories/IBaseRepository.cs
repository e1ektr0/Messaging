﻿using DomainEntities;

namespace Repositories
{
    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    public interface IRepository<out TEntity, in TKey> where TEntity : IKeyEntity
    {
        /// <summary>
        /// Получить сущность по ключу
        /// </summary>
        TEntity GetById(TKey key);
    }
}