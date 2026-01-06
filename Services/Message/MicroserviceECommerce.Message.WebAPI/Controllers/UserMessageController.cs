using MicroserviceECommerce.Message.WebAPI.Dtos;
using MicroserviceECommerce.Message.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Message.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserMessageController(IUserMessageService userMessageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllMessage()
    {
        var values = await userMessageService.GetAllMessageAsync();
        return Ok(values);
    }

    [HttpGet("GetMessageSendbox")]
    public async Task<IActionResult> GetMessageOutbox(string id)
    {
        var values = await userMessageService.GetOutboxMessageAsync(id);
        return Ok(values);
    }

    [HttpGet("GetMessageInbox")]
    public async Task<IActionResult> GetMessageInbox(string id)
    {
        var values = await userMessageService.GetInboxMessageAsync(id);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
    {
        await userMessageService.CreateMessageAsync(createMessageDto);
        return Ok("Mesaj başarıyla eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMessageAsync(int id)
    {
        await userMessageService.DeleteMessageAsync(id);
        return Ok("Mesaj başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMessageAsync(UpdateMessageDto updateMessageDto)
    {
        await userMessageService.UpdateMessageAsync(updateMessageDto);
        return Ok("Mesaj başarıyla güncellendi");
    }

    [HttpGet("GetTotalMessageCount")]
    public async Task<IActionResult> GetTotalMessageCount()
    {
        int values = await userMessageService.GetTotalMessageCount();
        return Ok(values);
    }

    [HttpGet("GetTotalMessageCountByReceiverId")]
    public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
    {
        int values = await userMessageService.GetTotalMessageCountByReceiverId(id);
        return Ok(values);
    }
}