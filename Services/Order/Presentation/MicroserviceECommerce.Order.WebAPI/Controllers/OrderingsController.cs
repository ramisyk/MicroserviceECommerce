using MediatR;
using MicroserviceECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Order.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderingsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOrderingList()
    {
        var values = await mediator.Send(new GetOrderingQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderingById(int id)
    {
        var value = await mediator.Send(new GetOrderingByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrdering([FromBody] CreateOrderingCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrdering([FromBody] UpdateOrderingCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrdering(int id)
    {
        await mediator.Send(new DeleteOrderingCommand(id));
        return Ok();
    }

    [HttpGet("GetOrderingByUserId/{id}")]
    public async Task<IActionResult> GetOrderingByUserId(string id)
    {
        var values = await mediator.Send(new GetOrderingByUserIdQuery(id));
        return Ok(values);
    }
}