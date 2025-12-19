using MicroserviceECommerce.Comment.WebAPI.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Comment.WebAPI.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class CommentStatisticsController(CommentDbContext commentContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCommentCount()
    {
        int values = await commentContext.UserComments.CountAsync();
        return Ok(values);
    }
}