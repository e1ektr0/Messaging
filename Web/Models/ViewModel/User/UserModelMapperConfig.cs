using AutoMapper;
using DomainEntities;
using Web.MapperConfigs;

namespace Web.Controllers.Admin
{
    public class UserModelMapperConfig : EntityModelBaseMapConfig<MembershipUser, UserModel>
    {
        private readonly ButtonFactory _buttonFactory;

        public UserModelMapperConfig(ButtonFactory buttonFactory)
        {
            _buttonFactory = buttonFactory;
        }

        protected override void MapToModel(IMappingExpression<MembershipUser, UserModel> map)
        {
            map.AfterMap((entity, model) => model.DeleteButton = _buttonFactory.DeleteButton<UsersController>(x => x.Delete(entity.Id)));
        }

        protected override void MapToEntity(IMappingExpression<UserModel, MembershipUser> map)
        {
        }
    }
}