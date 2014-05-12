using System;
using System.Security.Principal;
using DataBaseModel;
using DomainEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using Repositories;
using Services.Contracts;
using Services.Entities;
using Services.Security;
using Services.Security.SecurityActions;
using ServicesUnitTest.Helpers;

namespace ServicesUnitTest.Entities
{
    /// <summary>
    /// Unit тест MessageService
    /// </summary>
    [TestClass]
    public class MessageServiceUnitTest
    {
        #region Properties & Initialize

        private StandardKernel _kernel;
        private MessageService _messageService;
        private Guid _userGuid;
        private Mock<IMessagesRepository> _messageRepositoryMock;
        private Mock<ISecurityService<Message, MessageSecurityActions>> _securityServiceMock;
        private Mock<ISendMessageNotification> _sendMessageNotificationMock;
        private Mock<IUserRepositories> _userRepositoryMock;
        private Mock<IContext<Message>> _contextMock;

        [TestInitialize]
        public void Initialize()
        {
            _kernel = new StandardKernel();
            _userGuid = Guid.NewGuid();

            //Содаём моки основных объектов
            _messageRepositoryMock = new Mock<IMessagesRepository>();
            _securityServiceMock = new Mock<ISecurityService<Message, MessageSecurityActions>>();
            _userRepositoryMock = new Mock<IUserRepositories>();
            _sendMessageNotificationMock = new Mock<ISendMessageNotification>();
            _contextMock = new Mock<IContext<Message>>();

            //Регистрируем в IoC
            _kernel.Bind<IPrincipal>().ToConstant(PrincipalHelper.CreateUser(_userGuid));
            _kernel.Bind<IContext<Message>>().ToConstant(_contextMock.Object);
            _kernel.Bind<IMessagesRepository>().ToConstant(_messageRepositoryMock.Object);
            _kernel.Bind<ISecurityService<Message, MessageSecurityActions>>().ToConstant(_securityServiceMock.Object);
            _kernel.Bind<ISendMessageNotification>().ToConstant(_sendMessageNotificationMock.Object);
            _kernel.Bind<IUserRepositories>().ToConstant(_userRepositoryMock.Object);

            //Резолвим сервис
            _messageService = _kernel.Get<MessageService>();
        }

        #endregion

        #region SendMessage

        /// <summary>
        /// Проверяем что отправителем установлен текущий пользователь
        /// </summary>
        [TestMethod]
        public void SendMessage_SetCurrentUserAsSender()
        {
            // Arrange
            var message = new Message();

            // Act  
            _messageService.SendMessage(message);

            // Assert
            Assert.AreEqual(_userGuid.ToString("N"), message.SenderId);
        }

        /// <summary>
        /// Проверяем что вызван сервис проверки доступа
        /// </summary>
        [TestMethod]
        public void SendMessage_CheckAccess()
        {
            // Arrange
            var message = new Message();

            // Act  
            _messageService.SendMessage(message);

            // Assert
            _securityServiceMock.Verify(n => n.Check(message, MessageSecurityActions.Send), Times.Once);
        }

        /// <summary>
        /// Уставлена текущая дата отправки сообщения
        /// </summary>
        [TestMethod]
        public void SendMessage_SetCurrentDate()
        {
            // Arrange
            var message = new Message();

            // Act  
            _messageService.SendMessage(message);

            // Assert
            Assert.AreEqual(DateTime.Now.Date, message.SendDate.Date);
        }

        /// <summary>
        /// Что был вызван метод добавления и сохранения в ДБ
        /// </summary>
        [TestMethod]
        public void SendMessage_AddAndSaveToDb()
        {
            // Arrange
            var message = new Message();

            // Act  
            _messageService.SendMessage(message);

            // Assert
            _contextMock.Verify(n => n.Add(message), Times.Once);
            _contextMock.Verify(n => n.Comit(), Times.Once);
        }

        /// <summary>
        /// Было выслано уведоблемение получателю с материализоваными данными из БД.
        /// </summary>
        [TestMethod]
        public void SendMessage_NotyWithFullData()
        {
            // Arrange
            var message = new Message();
            var user = new MembershipUser();
            _userRepositoryMock.Setup(n => n.GetById(It.IsAny<string>())).Returns(user);

            // Act  
            _messageService.SendMessage(message);

            // Assert
            _sendMessageNotificationMock.Verify(n => n.Noty(It.Is<Message>(x => x.Sender == user && x.Receiver == user)));
        }

        #endregion SendMessage

        #region DeleteInputMessage

        /// <summary>
        /// Проверяем что вызван сервис проверки доступа
        /// </summary>
        [TestMethod]
        public void DeleteInputMessage_CheckAccess()
        {
            // Arrange
            const int messageId = 10;
            var message = new Message();
            _messageRepositoryMock.Setup(n => n.GetById(messageId)).Returns(message);

            // Act  
            _messageService.DeleteInputMessage(messageId);

            // Assert
            _securityServiceMock.Verify(n => n.Check(message, MessageSecurityActions.DeleteInput), Times.Once);
        }

        /// <summary>
        /// Проверяем что статус сообщеня для получателя установлен в удалён
        /// </summary>
        [TestMethod]
        public void DeleteInputMessage_CheckDeleted()
        {
            // Arrange
            const int messageId = 10;
            var message = new Message();
            _messageRepositoryMock.Setup(n => n.GetById(messageId)).Returns(message);

            // Act  
            _messageService.DeleteInputMessage(messageId);

            // Assert
            Assert.IsTrue(message.DeleteReceiver);
            Assert.IsFalse(message.DeleteSender);
            _contextMock.Verify(n => n.Update(message), Times.Once);
            _contextMock.Verify(n => n.Delete(message), Times.Never);
            _contextMock.Verify(n => n.Comit(), Times.Once);
        }

        #endregion DeleteInputMessage

        #region DeleteOutputMessage

        /// <summary>
        /// Проверяем что вызван сервис проверки доступа
        /// </summary>
        [TestMethod]
        public void DeleteOutputMessage_CheckAccess()
        {
            // Arrange
            const int messageId = 10;
            var message = new Message();
            _messageRepositoryMock.Setup(n => n.GetById(messageId)).Returns(message);

            // Act  
            _messageService.DeleteOutputMessage(messageId);

            // Assert
            _securityServiceMock.Verify(n => n.Check(message, MessageSecurityActions.DeleteOutput), Times.Once);
        }

        /// <summary>
        /// Проверяем что статус сообщеня для отправителя установлен в удалён
        /// </summary>
        [TestMethod]
        public void DeleteOutputMessage_CheckDeleted()
        {
            // Arrange
            const int messageId = 10;
            var message = new Message();
            _messageRepositoryMock.Setup(n => n.GetById(messageId)).Returns(message);

            // Act  
            _messageService.DeleteOutputMessage(messageId);

            // Assert
            Assert.IsTrue(message.DeleteSender);
            Assert.IsFalse(message.DeleteReceiver);
            _contextMock.Verify(n => n.Update(message), Times.Once);
            _contextMock.Verify(n => n.Delete(message), Times.Never);
            _contextMock.Verify(n => n.Comit(), Times.Once);
        }

        #endregion DeleteInputMessage
    }
}
