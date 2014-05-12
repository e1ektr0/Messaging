using AutoMapper;
using DomainEntities;
using Web.Models.Dto;

namespace Web.MapperConfigs
{
    public class MembershipUserMapperConfig : EntityModelBaseMapConfig<MembershipUser, UserDto>
    {
        protected override void MapToModel(IMappingExpression<MembershipUser, UserDto> map)
        {
            map.ForMember(m => m.Email, n => n.MapFrom(x => x.UserName));
        }

        protected override void MapToEntity(IMappingExpression<UserDto, MembershipUser> map)
        {
            map.ForMember(m => m.UserName, n => n.MapFrom(x => x.Email));
        }
    }
}