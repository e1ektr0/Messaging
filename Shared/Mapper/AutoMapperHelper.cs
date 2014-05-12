using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject;

namespace Shared.Mapper
{
    /// <summary>
    /// Класс содержащий вспомогательные методы для маппинга сущностей
    /// </summary>
    public static class AutoMapperHelper
    {

        /// <summary>
        /// Функция регистрирует все объекты реализующие интерфейс IMapConfig
        /// </summary>
        public static void RegistrMapperConfigs()
        {
            var potencialConfig = Assembly.GetCallingAssembly().GetTypes()
                .Where(n => !n.IsAbstract && n.IsClass && typeof (IMapConfig).IsAssignableFrom(n));
            foreach (var type in potencialConfig)
            {
                var config = (IMapConfig) IoC.IoC.Instance.Get(type);
                config.ConfigMapToDestination();
                config.ConfigMapToSourse();
            }
        }

        /// <summary>
        /// Маппинг в сущность
        /// </summary>
        public static TU MapTo<T, TU>(this T from, TU toEntity)
        {
            AutoMapper.Mapper.Map(from, toEntity);
            return toEntity;
        }

        /// <summary>
        /// Маппинг колекции
        /// </summary>
        public static IEnumerable<TU> Select<T, TU>(this IEnumerable<T> from, TU obj)
            where TU : new()
        {
            return from.Select(n => n.MapTo(new TU()));
        }
    }
}