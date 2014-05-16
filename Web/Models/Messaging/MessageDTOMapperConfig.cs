using AutoMapper;
using DomainEntities;
using Shared.Mapper;
using Web.Models.Dto;

namespace Web.Models.Messaging
{
    /// <summary>
    /// Маппит сообщения в json объект
    /// </summary>
    public class MessageDTOMapperConfig : EntityModelBaseMapConfig<Message, MessageDTO>
    {
        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected override void MapToModel(IMappingExpression<Message, MessageDTO> map)
        {
            map.ForMember(n => n.Content, e => e.MapFrom(x => x.Text));

        }

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected override void MapToEntity(IMappingExpression<MessageDTO, Message> map)
        {
            map.ForMember(n => n.Text, e => e.MapFrom(x => x.Content));
        }
    }
}