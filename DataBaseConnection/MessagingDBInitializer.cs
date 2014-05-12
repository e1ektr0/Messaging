using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DomainEntities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataBaseModel
{
    /// <summary>
    /// Инициализатор базы данных
    /// </summary>
    public class MessagingDbInitializer : CreateDatabaseIfNotExists<Context>
    {

        /// <summary>
        /// Заполнение тестовыми данными
        /// </summary>
        /// <param name="context">Контекст БД</param>
        protected override void Seed(Context context)
        {
            const string userPassword = "123456";

            var userStore = new UserStore<MembershipUser>(context);
            var userManager = new UserManager<MembershipUser>(userStore);
            AddUsers(userManager, userPassword);
            var list = AddMessages(userManager);

            context.Messages.AddOrUpdate(list.ToArray());
            context.SaveChanges();
            base.Seed(context);
        }

        /// <summary>
        /// Добавляет тестовые сообщения
        /// </summary>
        private static List<Message> AddMessages(UserManager<MembershipUser> userManager)
        {
            var users = userManager.Users.ToList();
            var list = new List<Message>();
            foreach (var fromUser in users)
                foreach (var toUser in users)
                {
                    if (fromUser.Id == toUser.Id)
                        continue;
                    for (var i = 0; i < 100; i++)
                    {
                        var message = new Message
                        {
                            SenderId = fromUser.Id,
                            ReceiverId = toUser.Id,
                            SendDate = DateTime.Now.AddMinutes(-i),
                            Subject = i + " From: " + fromUser.UserName + " to: " + toUser.UserName,
                            Text = "Hello " + toUser.UserName + Environment.NewLine + i + Environment.NewLine + " Regards, " + fromUser.UserName
                        };
                        list.Add(message);
                    }
                }
            return list;
        }

        /// <summary>
        /// Добавляет тестовых пользователей
        /// </summary>
        private static void AddUsers(UserManager<MembershipUser> userManager, string userPassword)
        {
            var users = new List<MembershipUser>
            {
                new MembershipUser
                {
                    UserName = "minimal@user.com",
                },
                new MembershipUser
                {
                    UserName = "withFirstName@user.com",
                    FirstName = "UserFirstName",
                },
                new MembershipUser
                {
                    UserName = "withFirstAndLastName@user.com",
                    FirstName = "UserFirstName",
                    LastName = "UserLastName"
                },
                new MembershipUser
                {
                    UserName = "maximal@user.com",
                    FirstName = "UserFirstName",
                    LastName = "UserLastName",
                    PhoneNumber = "12345"
                }
            };

            foreach (var membershipUser in users)
            {
                userManager.Create(membershipUser, userPassword);
            }
        }
    }
}