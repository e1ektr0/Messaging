using AutoMapper;
using DomainEntities;
using Shared.Mapper;

namespace Web.Models.ViewModel.Accaunt
{
    /// <summary>
    /// Мапер формы регистрации
    /// </summary>
    public class RegisterViewModelMapperConfig : EntityModelBaseMapConfig<RegisterViewModel, MembershipUser>
    {
        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected override void MapToModel(IMappingExpression<RegisterViewModel, MembershipUser> map)
        {
            map.ForAllMembers(n => n.Ignore());
            map.ForMember(n => n.UserName, e => e.MapFrom(u => u.Email));
            map.ForMember(n => n.FirstName, e => e.MapFrom(u => u.FirstName));
            map.ForMember(n => n.LastName, e => e.MapFrom(u => u.LastName));
            map.ForMember(n => n.PhoneNumber, e => e.MapFrom(u => u.Phone));
        }

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected override void MapToEntity(IMappingExpression<MembershipUser, RegisterViewModel> map)
        {
            map.ForAllMembers(n => n.Ignore());
        }
    }
}