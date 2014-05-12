using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ninject;
using Shared.IoC;

namespace Services.Security
{
    /// <summary>
    /// Атрибут фильтрации доступа к объектам
    /// Используется на тех действиях, которые работают непосредсвенно с репозиториями, а не с сервисами,
    /// в котороых обязатьно должна быть провека в каждом методе
    /// </summary>
    public class SecurityObjectAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Тип объекта
        /// </summary>
        private readonly Type _securityObjectType;
        
        /// <summary>
        /// Дейсвие безопасности
        /// </summary>
        private readonly object _action;

        /// <summary>
        /// Имя входного параметра, в котором содержится ключ объекта
        /// </summary>
        private readonly string _keyName;

        public SecurityObjectAttribute(Type securityObjectType, object action, string keyName = "id")
        {
            _securityObjectType = securityObjectType;
            _action = action;
            _keyName = keyName;
        }

        /// <summary>
        /// Проверка доступа
        /// </summary>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //Ключ объекта
            var key = actionContext.Request.GetRouteData().Values[_keyName];

            //Получаем тип сервиса
            var seviceType = typeof(ISecurityService<,>);
            var types = new[] { _securityObjectType, _action.GetType() };
            var genericType = seviceType.MakeGenericType(types);
            dynamic service = IoC.Instance.Get(genericType) ;
            if (service == null)
                throw new Exception("Security service not found!");
            
            //Осуществляем проверку
            service.Check(null, _action, key);
        }
    }
}