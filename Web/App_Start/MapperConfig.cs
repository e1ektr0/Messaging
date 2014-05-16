using Shared.Mapper;

namespace Web
{
    /// <summary>
    /// Конфиг маппера
    /// </summary>
    public static class MapperConfig
    {
        /// <summary>
        /// Регистрирует все мапы конфига
        /// </summary>
        public static void CreateMaps()
        {
            AutoMapperHelper.RegistrMapperConfigs();
        }
    }
}