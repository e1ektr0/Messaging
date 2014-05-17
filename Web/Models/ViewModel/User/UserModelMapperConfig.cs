using AutoMapper;
using DomainEntities;
using Shared.Mapper;
using Web.Controllers.Admin;
using Web.Models.Button;

namespace Web.Models.ViewModel.User
{
    /// <summary>
    /// Маппер для элемента в списке пользователей
    /// </summary>
    public class UserModelMapperConfig : EntityModelBaseMapConfig<MembershipUser, UserRowModel>
    {
        private readonly ButtonFactory _buttonFactory;

        /// <summary>
        /// Конструктор маппера
        /// </summary>
        public UserModelMapperConfig(ButtonFactory buttonFactory)
        {
            _buttonFactory = buttonFactory;
        }

        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected override void MapToModel(IMappingExpression<MembershipUser, UserRowModel> map)
        {
            map.AfterMap((entity, model) => model.DeleteButton = _buttonFactory.DeleteButton<AdminUsersController>(x => x.Delete(entity.Id)));
        }

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected override void MapToEntity(IMappingExpression<UserRowModel, MembershipUser> map)
        {
        }
    }
}