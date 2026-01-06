using MicroserviceECommerce.Message.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Message.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserMessageStatisticsController(IUserMessageService userMessageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTotalMessageCount()
    {
        int messageCount = await userMessageService.GetTotalMessageCount();
        return Ok(messageCount);
    }
}