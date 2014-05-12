using AutoMapper;
using DomainEntities;
using Web.Models;
using Web.Models.ViewModel;

namespace Web.MapperConfigs
{
    public class AccountEditViewModelMapperConfig : EntityModelBaseMapConfig<AccountEditViewModel, MembershipUser>
    {
        protected override void MapToModel(IMappingExpression<AccountEditViewModel, MembershipUser> map)
        {
            map.ForAllMembers(n => n.Ignore());
            map.ForMember(n => n.FirstName, e => e.MapFrom(u => u.FirstName));
            map.ForMember(n => n.LastName, e => e.MapFrom(u => u.LastName));
            map.ForMember(n => n.PhoneNumber, e => e.MapFrom(u => u.Phone));
        }

        protected override void MapToEntity(IMappingExpression<MembershipUser, AccountEditViewModel> map)
        {
            map.ForMember(n => n.FirstName, e => e.MapFrom(u => u.FirstName));
            map.ForMember(n => n.LastName, e => e.MapFrom(u => u.LastName));
            map.ForMember(n => n.Phone, e => e.MapFrom(u => u.PhoneNumber));
        }
    }
}