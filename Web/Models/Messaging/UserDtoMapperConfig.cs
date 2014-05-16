using AutoMapper;
using DomainEntities;
using Shared.Mapper;
using Web.MapperConfigs;

namespace Web.Models.Messaging
{
    /// <summary>
    /// Маппинг сужности юзхера для передачи через json
    /// </summary>
    public class UserDtoMapperConfig : EntityModelBaseMapConfig<MembershipUser, UserDto>
    {
        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected override void MapToModel(IMappingExpression<MembershipUser, UserDto> map)
        {
            map.ForMember(m => m.Email, n => n.MapFrom(x => x.UserName));
        }

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected override void MapToEntity(IMappingExpression<UserDto, MembershipUser> map)
        {
            map.ForMember(m => m.UserName, n => n.MapFrom(x => x.Email));
        }
    }
}