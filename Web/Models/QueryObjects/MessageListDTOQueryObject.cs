using System;
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
        public void AddOrdering<TKeySelector>(Expression<Func<TModel, object>> keyExpression,
            Expression<Func<TEntity, TKeySelector>> orderExpression)
        {
            AddOrdering(new TModel().GetPropertyName(keyExpression), orderExpression);
        }
    }

    /// <summary>
    /// Объект запроса для сообщений
    /// </summary>
    public class MessageListDTOQueryObject : ModelQueryObject<MessageListDTO,Message>
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
        protected override Expression<Func<MembershipUser, bool>> Filter()
        {
            var filter = base.Filter();
            if (!Search.IsNullOrEmpty())
            {
                filter.And(n => n.Id.Contains(Search));
                filter.And(n => n.FirstName.Contains(Search));
                filter.And(n => n.LastName.Contains(Search));
            }

            return filter;
        }
    }
}