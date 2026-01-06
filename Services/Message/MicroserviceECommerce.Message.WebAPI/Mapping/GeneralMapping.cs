using AutoMapper;
using MicroserviceECommerce.Message.WebAPI.DAL.Entities;
using MicroserviceECommerce.Message.WebAPI.Dtos;

namespace MicroserviceECommerce.Message.WebAPI.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
        CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
        CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultOutboxMessageDto>().ReverseMap();
        CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
    }
}