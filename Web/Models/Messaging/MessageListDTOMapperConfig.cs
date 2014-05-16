using AutoMapper;
using DomainEntities;
using Shared.Mapper;
using Web.Models.Dto;

namespace Web.MapperConfigs
{
    /// <summary>
    /// Маппер сообщений в dto 
    /// </summary>
    public class MessageListDTOMapperConfig : EntityModelBaseMapConfig<Message, MessageListDTO>
    {
        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected override void MapToModel(IMappingExpression<Message, MessageListDTO> map)
        {
            map.ForMember(n => n.SendDate, m => m.MapFrom(x => x.SendDate.ToString("dd.MM.yyyy HH:mm:ss")))
                .ForMember(n => n.ReceiverName, m => m.MapFrom(x => x.Receiver.GetFullName()))
                .ForMember(n => n.ReceiverEmail, m => m.MapFrom(x => x.Receiver.UserName))
                .ForMember(n => n.SenderName, m => m.MapFrom(x => x.Sender.GetFullName()))
                .ForMember(n => n.SenderEmail, m => m.MapFrom(x => x.Sender.UserName))
                .ForMember(n => n.Content, m => m.MapFrom(x => x.Text));
        }

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected override void MapToEntity(IMappingExpression<MessageListDTO, Message> map)
        {
        }
    }
}