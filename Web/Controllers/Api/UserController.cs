﻿using System.Collections.Generic;
using System.Web.Http;
using DomainEntities;
using Repositories;
using Services.Security;
using Services.Security.SecurityActions;
using Shared.Mapper;
using Web.Models.Dto;

namespace Web.Controllers.Api
{
    /// <summary>
    /// Api контроллер пользователей
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        private readonly UserRepositories _repositories;

        public UserController(UserRepositories repositories)
        {
            _repositories = repositories;
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SecurityObject(typeof(MembershipUser), DefaultSecurityActions.GetList)]
        public IEnumerable<UserDto> Get()
        {
            return _repositories.GetUsersForSendMessage().Select(new UserDto());
        }

        /// <summary>
        /// Получить конкретного пользователя
        /// </summary>
        [HttpGet]
        [SecurityObject(typeof(MembershipUser), DefaultSecurityActions.GetById)]
        public UserDto GetById(string id)
        {
            return _repositories.GetById(id).MapTo(new UserDto());
        }
    }
}
