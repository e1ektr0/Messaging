using AutoMapper;
using DomainEntities;
using Shared.Mapper;
using Web.Controllers.Admin;
using Web.Models.Button;

namespace Web.Models.ViewModel.User
{
    /// <summary>
    /// ������ ��� �������� � ������ �������������
    /// </summary>
    public class UserModelMapperConfig : EntityModelBaseMapConfig<MembershipUser, UserRowModel>
    {
        private readonly ButtonFactory _buttonFactory;

        /// <summary>
        /// ����������� �������
        /// </summary>
        public UserModelMapperConfig(ButtonFactory buttonFactory)
        {
            _buttonFactory = buttonFactory;
        }

        /// <summary>
        /// ����� ��� �������� �� �������� ��
        /// </summary>
        protected override void MapToModel(IMappingExpression<MembershipUser, UserRowModel> map)
        {
            map.AfterMap((entity, model) => model.DeleteButton = _buttonFactory.DeleteButton<AdminUsersController>(x => x.Delete(entity.Id)));
        }

        /// <summary>
        /// ����� ��� �������� � �������� ��
        /// </summary>
        protected override void MapToEntity(IMappingExpression<UserRowModel, MembershipUser> map)
        {
        }
    }
}