using AutoMapper;
using DomainEntities;
using Shared.Mapper;
using Web.Models.ViewModel.Accaunt;

namespace Web.MapperConfigs
{
    /// <summary>
    /// Мапиинг модели аккаунта
    /// </summary>
    public class AccountEditViewModelMapperConfig : EntityModelBaseMapConfig<AccountEditViewModel, MembershipUser>
    {
        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected override void MapToModel(IMappingExpression<AccountEditViewModel, MembershipUser> map)
        {
            map.ForAllMembers(n => n.Ignore());
            map.ForMember(n => n.FirstName, e => e.MapFrom(u => u.FirstName));
            map.ForMember(n => n.LastName, e => e.MapFrom(u => u.LastName));
            map.ForMember(n => n.PhoneNumber, e => e.MapFrom(u => u.Phone));
        }

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected override void MapToEntity(IMappingExpression<MembershipUser, AccountEditViewModel> map)
        {
            map.ForMember(n => n.FirstName, e => e.MapFrom(u => u.FirstName));
            map.ForMember(n => n.LastName, e => e.MapFrom(u => u.LastName));
            map.ForMember(n => n.Phone, e => e.MapFrom(u => u.PhoneNumber));
        }
    }
}