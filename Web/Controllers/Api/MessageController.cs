using System.Collections.Generic;
using System.Web.Http;
using DomainEntities;
using Repositories;
using Services.Entities;
using Services.Security;
using Services.Security.SecurityActions;
using Shared.Mapper;
using Web.Models.Dto;
using Web.Models.QueryObjects;

namespace Web.Controllers.Api
{
    /// <summary>
    /// Api контроллер сообщений
    /// </summary>
    public class MessageController : ApiController
    {
        #region Constructor & properties

        /// <summary>
        /// Сервис сообщений
        /// </summary>
        private readonly MessageService _messageService;

        /// <summary>
        /// Репозиторий сообщений
        /// </summary>
        private readonly MessagesRepository _messagesRepository;

        public MessageController(MessageService messageService, MessagesRepository messagesRepository)
        {
            _messageService = messageService;
            _messagesRepository = messagesRepository;
        }

        #endregion  Constructor & properties

        #region Actions

        /// <summary>
        /// Получить сообщение по id
        /// </summary>
        [HttpGet]
        [SecurityObject(typeof (Message), MessageSecurityActions.GetById)]
        public MessageListDTO GetById(int id)
        {
            return _messagesRepository.GetById(id).MapTo(new MessageListDTO());
        }


        /// <summary>
        /// Получить входящие сообщения
        /// </summary>
        [HttpPost]
        [ActionName("input")]
        [SecurityObject(typeof (Message), MessageSecurityActions.GetList)]
        public IEnumerable<MessageListDTO> GetInput(MessageListDTOQueryObject queryObject)
        {
            return _messagesRepository.GetInput(queryObject).Select(new MessageListDTO());
        }

        /// <summary>
        /// Получить исходящие сообщения
        /// </summary>
        [HttpPost]
        [ActionName("output")]
        [SecurityObject(typeof (Message), MessageSecurityActions.GetList)]
        public IEnumerable<MessageListDTO> GetOutput(MessageListDTOQueryObject queryObject)
        {
            return _messagesRepository.GetOutput(queryObject).Select(new MessageListDTO());
        }

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        [HttpPost]
        [ActionName("SendMessage")]
        public void SendMessage(MessageDTO messageDto)
        {
            var message = messageDto.MapTo(new Message());
            _messageService.SendMessage(message);
        }

        /// <summary>
        /// Удалить сообщение
        /// </summary>
        [HttpPost]
        [ActionName("deleteinput")]
        public void DeleteInputMessage(int id)
        {
            _messageService.DeleteInputMessage(id);
        }

        /// <summary>
        /// Удалить сообщение
        /// </summary>
        [HttpPost]
        [ActionName("deleteoutput")]
        public void DeleteOutputMessage(int id)
        {
            _messageService.DeleteOutputMessage(id);
        }

        #endregion Actions
    }
}