using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace ServicesUnitTest.Helpers
{
    /// <summary>
    /// Хелпер для создания пользователя для тестирования
    /// </summary>
    public static class PrincipalHelper
    {
        /// <summary>
        /// Создаст пользователя с указаным guid
        /// </summary>
        public static IPrincipal CreateUser(Guid guid)
        {
            const string username = "username";
            var userid = guid.ToString("N"); 

            var claims = new List<Claim>();
            claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userid));
            claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            var genericIdentity = new GenericIdentity("");
            genericIdentity.AddClaims(claims);
            var genericPrincipal = new GenericPrincipal(genericIdentity, new[] { "Asegurado" });
            return genericPrincipal;
        }
    }
}
