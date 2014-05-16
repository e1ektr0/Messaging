using DomainEntities;
using Repositories.QueryObject;
using Shared.Extensions;
using Web.Models.ViewModel.User;

namespace Web.Models.QueryObjects
{
    /// <summary>
    /// Описание связываниея модели строки с запросом в базу данных
    /// </summary>
    public class UsersQueryObject : ModelQueryObject<UserRowModel, MembershipUser>
    {
        /// <summary>
        /// Конструктор
        /// Инициализация сортировки
        /// </summary>
        public UsersQueryObject()
        {
            //Описываем сортировку
            AddOrdering(model => model.Id, entity => entity.Id);
            AddOrdering(model => model.FirstName, entity => entity.FirstName);
            AddOrdering(model => model.LastName, entity => entity.LastName);
        }

        /// <summary>
        /// Генерирует ограничение на запрос(опираясь на обхект запроса)
        /// </summary>
        protected override Conditional<MembershipUser> Filter()
        {
            var filter = new Conditional<MembershipUser>(true);

            //Глобальный поиск
            GlobalConditional(filter);

            //Описываем ограничения по колонкам
            ColumnConditional(filter);
            return filter;
        }

        /// <summary>
        /// Описывает ограничения для поиска по всем колонкам
        /// </summary>
        private void GlobalConditional(Conditional<MembershipUser> filter)
        {
            if (Search.IsNullOrEmpty()) 
                return;

            var searchCondition = new Conditional<MembershipUser>(false);
            searchCondition.Or(n => n.Id.Contains(Search));
            searchCondition.Or(n => n.FirstName.Contains(Search));
            searchCondition.Or(n => n.LastName.Contains(Search));
            filter.And(searchCondition);
        }

        /// <summary>
        /// Описываем ограничения по колонкам
        /// </summary>
        private void ColumnConditional(Conditional<MembershipUser> filter)
        {
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
        }

    }
}