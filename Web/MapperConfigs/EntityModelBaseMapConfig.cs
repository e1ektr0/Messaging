using AutoMapper;
using Shared.Mapper;

namespace Web.MapperConfigs
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
            return Mapper.CreateMap<TModel, TEntity>();
        }

        private static IMappingExpression<TEntity, TModel> ToSourseMap()
        {
            return Mapper.CreateMap<TEntity, TModel>();
        }


        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected abstract void MapToModel(IMappingExpression<TEntity, TModel> map);

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected abstract void MapToEntity(IMappingExpression<TModel, TEntity> map);

        public virtual void ConfigMapToSourse()
        {
            MapToModel(ToSourseMap());
        }

        public virtual void ConfigMapToDestination()
        {
            MapToEntity(ToDestinationMap());
        }
    }
}