using AutoMapper;

namespace Shared.Mapper
{
    /// <summary>
    /// Базовая сущность для конфига авто мапера, создаёт карты автомапера
    /// </summary>
    /// <typeparam name="TEntity">Сущность базы</typeparam>
    /// <typeparam name="TModel">Сущность модели</typeparam>
    public abstract class EntityModelBaseMapConfig<TEntity, TModel> : IMapConfig
    {
        private static IMappingExpression<TModel, TEntity> ToDestinationMap()
        {
            return AutoMapper.Mapper.CreateMap<TModel, TEntity>();
        }

        private static IMappingExpression<TEntity, TModel> ToSourseMap()
        {
            return AutoMapper.Mapper.CreateMap<TEntity, TModel>();
        }


        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected abstract void MapToModel(IMappingExpression<TEntity, TModel> map);

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected abstract void MapToEntity(IMappingExpression<TModel, TEntity> map);

        /// <summary>
        /// Генерирует карту для исходной сущности
        /// </summary>
        public virtual void ConfigMapToSourse()
        {
            MapToModel(ToSourseMap());
        }

        /// <summary>
        /// Генерирует карту для конечной сущности
        /// </summary>
        public virtual void ConfigMapToDestination()
        {
            MapToEntity(ToDestinationMap());
        }
    }
}