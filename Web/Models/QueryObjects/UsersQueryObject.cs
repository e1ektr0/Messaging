using DomainEntities;
using Repositories.QueryObject;
using Shared.Extensions;
using Web.Controllers.Admin;

namespace Web.Models.QueryObjects
{
    public class UsersQueryObject : ModelQueryObject<UserModel, MembershipUser>
    {
        public UsersQueryObject()
        {
            AddOrdering(n => n.Id, n => n.Id);
            AddOrdering(n => n.FirstName, n => n.FirstName);
            AddOrdering(n => n.LastName, n => n.LastName);
        }

        protected override Conditional<MembershipUser> Filter()
        {
            var filter = new Conditional<MembershipUser>(true);

            if (!Search.IsNullOrEmpty())
            {
                var searchCondition = new Conditional<MembershipUser>(false);
                searchCondition.Or(n => n.Id.Contains(Search));
                searchCondition.Or(n => n.FirstName.Contains(Search));
                searchCondition.Or(n => n.LastName.Contains(Search));
                filter.And(searchCondition);
            }

            if (HasConditional(model => model.Id))
            {
                var conditional = GetConditional(model => model.Id);
                filter.And(entity => entity.Id.Contains(conditional));
            }

            if (HasConditional(model => model.FirstName))
            {
                var conditional = GetConditional(model => model.FirstName);
                filter.And(entity => entity.FirstName.Contains(conditional));
            }

            if (HasConditional(model => model.LastName))
            {
                var conditional = GetConditional(model => model.LastName);
                filter.And(enityt => enityt.LastName.Contains(conditional));
            }
            return filter;
        }
    }
}