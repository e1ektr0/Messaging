using Microsoft.AspNet.Identity.EntityFramework;

namespace DomainEntities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class MembershipUser : IdentityUser, IKeyEntity
    {
        #region Properties

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Агрегирует полное имя пользователя
        /// </summary>
        public string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        #endregion Public Methods
    }
}
