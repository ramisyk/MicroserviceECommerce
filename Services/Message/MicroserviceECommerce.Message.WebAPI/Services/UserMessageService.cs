using AutoMapper;
using MicroserviceECommerce.Message.WebAPI.DAL.Context;
using MicroserviceECommerce.Message.WebAPI.DAL.Entities;
using MicroserviceECommerce.Message.WebAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Message.WebAPI.Services;

public class UserMessageService(MessageContext messageContext, IMapper mapper) : IUserMessageService
{
    public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
    {
        var value = mapper.Map<UserMessage>(createMessageDto);
        await messageContext.UserMessages.AddAsync(value);
        await messageContext.SaveChangesAsync();
    }
    public async Task DeleteMessageAsync(int id)
    {
        var values = await messageContext.UserMessages.FindAsync(id);
        messageContext.UserMessages.Remove(values);
        await messageContext.SaveChangesAsync();
    }
    public async Task<List<ResultMessageDto>> GetAllMessageAsync()
    {
        var values = await messageContext.UserMessages.ToListAsync();
        return mapper.Map<List<ResultMessageDto>>(values);
    }
    public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
    {
        var values = await messageContext.UserMessages.FindAsync(id);
        return mapper.Map<GetByIdMessageDto>(values);
    }
    public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
    {
        var values = await messageContext.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
        return mapper.Map<List<ResultInboxMessageDto>>(values);
    }
    public async Task<List<ResultOutboxMessageDto>> GetOutboxMessageAsync(string id)
    {
        var values = await messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
        return mapper.Map<List<ResultOutboxMessageDto>>(values);
    }

    public async Task<int> GetTotalMessageCount()
    {
        int values = await messageContext.UserMessages.CountAsync();
        return values;
    }

    public async Task<int> GetTotalMessageCountByReceiverId(string id)
    {
        var values = await messageContext.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
        return values;
    }

    public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
    {
        var values = mapper.Map<UserMessage>(updateMessageDto);
        messageContext.UserMessages.Update(values);
        await messageContext.SaveChangesAsync();
    }
}