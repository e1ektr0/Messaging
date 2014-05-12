using System.Data.Entity;
using DomainEntities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataBaseModel
{
    /// <summary>
    /// Контекст для работы с базой данный
    /// Заточен под code first
    /// Соединён с membership
    /// </summary>
    public class Context : IdentityDbContext<MembershipUser>
    {
        public Context() : base("DefaultConnection")
        {
            //Содаёт базу если её нет
            Database.SetInitializer(new MessagingDbInitializer());
        }

        /// <summary>
        /// Список сообщений
        /// </summary>
        public DbSet<Message> Messages { get; set; }
    }
}
