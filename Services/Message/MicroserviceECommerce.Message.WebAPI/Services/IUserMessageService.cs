using MicroserviceECommerce.Message.WebAPI.Dtos;

namespace MicroserviceECommerce.Message.WebAPI.Services;

public interface IUserMessageService
{
    Task<List<ResultMessageDto>> GetAllMessageAsync();
    Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
    Task<List<ResultOutboxMessageDto>> GetOutboxMessageAsync(string id);
    Task CreateMessageAsync(CreateMessageDto createMessageDto);
    Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
    Task DeleteMessageAsync(int id);
    Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    Task<int> GetTotalMessageCount();
    Task<int> GetTotalMessageCountByReceiverId(string id);
}