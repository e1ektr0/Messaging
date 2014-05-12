using AutoMapper;
using DomainEntities;
using Web.Models.Dto;

namespace Web.MapperConfigs
{
    public class MessageDTOMapperConfig : EntityModelBaseMapConfig<Message, MessageDTO>
    {
        protected override void MapToModel(IMappingExpression<Message, MessageDTO> map)
        {
            map.ForMember(n => n.Content, e => e.MapFrom(x => x.Text));

        }

        protected override void MapToEntity(IMappingExpression<MessageDTO, Message> map)
        {
            map.ForMember(n => n.Text, e => e.MapFrom(x => x.Content));
        }
    }
}