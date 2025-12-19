using MicroserviceECommerce.Comment.WebAPI.Context;
using MicroserviceECommerce.Comment.WebAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Comment.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentsController(CommentDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult CommentList()
    {
        var values = context.UserComments.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateComment(UserComment userComment)
    {
        context.UserComments.Add(userComment);
        context.SaveChanges();
        return Ok("Yorum başarıyla eklendi");
    }

    [HttpDelete]
    public IActionResult DeleteComment(int id)
    {
        var value = context.UserComments.Find(id);
        context.UserComments.Remove(value);
        context.SaveChanges();
        return Ok("Yorum başarıyla silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetComment(int id)
    {
        var value = context.UserComments.Find(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateComment(UserComment userComment)
    {
        context.UserComments.Update(userComment);
        context.SaveChanges();
        return Ok("Yorum başarıyla güncellendi");
    }

    [HttpGet("CommentListByProductId/{id}")]
    public IActionResult CommentListByProductId(string id)
    {
        var value = context.UserComments.Where(x => x.ProductId == id).ToList();
        return Ok(value);
    }

    [HttpGet("GetActiveCommentCount")]
    public IActionResult GetActiveCommentCount()
    {
        int value = context.UserComments.Where(x => x.Status == true).Count();
        return Ok(value);
    }

    [HttpGet("GetPassiveCommentCount")]
    public IActionResult GetPassiveCommentCount()
    {
        int value = context.UserComments.Where(x => x.Status == false).Count();
        return Ok(value);
    }

    [HttpGet("GetTotalCommentCount")]
    public IActionResult GetTotalCommentCount()
    {
        int value = context.UserComments.Count();
        return Ok(value);
    }
}