using AutoMapper;
using DomainEntities;
using Web.Models;
using Web.Models.ViewModel;

namespace Web.MapperConfigs
{
    public class RegisterViewModelMapperConfig : EntityModelBaseMapConfig<RegisterViewModel, MembershipUser>
    {
        protected override void MapToModel(IMappingExpression<RegisterViewModel, MembershipUser> map)
        {
            map.ForAllMembers(n => n.Ignore());
            map.ForMember(n => n.UserName, e => e.MapFrom(u => u.Email));
            map.ForMember(n => n.FirstName, e => e.MapFrom(u => u.FirstName));
            map.ForMember(n => n.LastName, e => e.MapFrom(u => u.LastName));
            map.ForMember(n => n.PhoneNumber, e => e.MapFrom(u => u.Phone));
        }

        protected override void MapToEntity(IMappingExpression<MembershipUser, RegisterViewModel> map)
        {
            map.ForAllMembers(n => n.Ignore());
        }
    }
}