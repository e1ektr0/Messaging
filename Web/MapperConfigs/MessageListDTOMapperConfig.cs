using AutoMapper;
using DomainEntities;
using Web.Models.Dto;

namespace Web.MapperConfigs
{
    public class MessageListDTOMapperConfig : EntityModelBaseMapConfig<Message, MessageListDTO>
    {
        protected override void MapToModel(IMappingExpression<Message, MessageListDTO> map)
        {
            map.ForMember(n => n.SendDate, m => m.MapFrom(x => x.SendDate.ToString("dd.MM.yyyy HH:mm:ss")))
                .ForMember(n => n.ReceiverName, m => m.MapFrom(x => x.Receiver.GetFullName()))
                .ForMember(n => n.ReceiverEmail, m => m.MapFrom(x => x.Receiver.UserName))
                .ForMember(n => n.SenderName, m => m.MapFrom(x => x.Sender.GetFullName()))
                .ForMember(n => n.SenderEmail, m => m.MapFrom(x => x.Sender.UserName))
                .ForMember(n => n.Content, m => m.MapFrom(x => x.Text));
        }

        protected override void MapToEntity(IMappingExpression<MessageListDTO, Message> map)
        {
        }
    }
}