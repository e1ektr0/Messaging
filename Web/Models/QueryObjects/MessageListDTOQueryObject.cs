using System;
using System.Linq;
using System.Linq.Expressions;
using DomainEntities;
using Repositories.QueryObject;
using Shared.Extensions;
using Web.Controllers.Admin;
using Web.Models.Dto;

namespace Web.Models.QueryObjects
{

    public abstract class ModelQueryObject<TModel, TEntity> : QueryObject<TEntity> where TModel : new()
    {
        protected void AddOrdering<TKeySelector>(Expression<Func<TModel, object>> keyExpression,
            Expression<Func<TEntity, TKeySelector>> orderExpression)
        {
            AddOrdering(GetPropertyKey(keyExpression), orderExpression);
        }

        protected bool HasConditional(Expression<Func<TModel, object>> keyExpression)
        {
            if (SearchCoditionals == null)
                return false;
            return SearchCoditionals.Any(n => n.Key == GetPropertyKey(keyExpression) && !n.Value.IsNullOrEmpty());
        }

        protected string GetConditional(Expression<Func<TModel, object>> keyExpression)
        {
            return SearchCoditionals.First(n => n.Key == GetPropertyKey(keyExpression)).Value;
        }


        private static string GetPropertyKey(Expression<Func<TModel, object>> keyExpression)
        {
            return new TModel().GetPropertyName(keyExpression);
        }
    }

    /// <summary>
    /// Объект запроса для сообщений
    /// </summary>
    public class MessageListDTOQueryObject : ModelQueryObject<MessageListDTO, Message>
    {
        public MessageListDTOQueryObject()
        {
            //Связываем поля dto объекта с правилами сортировки
            AddOrdering(n => n.SendDate, n => n.SendDate);
            AddOrdering(n => n.ReceiverName, n => n.Receiver.FirstName);
            AddOrdering(n => n.SenderName, n => n.Sender.FirstName);
            AddOrdering(n => n.Subject, n => n.Subject);
        }
    }

   

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