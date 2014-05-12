using Shared.Mapper;

namespace Web
{
    public static class MapperConfig
    {
        public static void CreateMaps()
        {
            AutoMapperHelper.RegistrMapperConfigs();
        }
    }
}