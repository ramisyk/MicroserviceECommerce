using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Order.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController(
    GetOrderDetailQueryHandler orderDetailQueryHandler,
    GetOrderDetailByIdQueryHandler orderDetailByIdQueryHandler,
    CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
    UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler,
    DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOrderDetails()
    {
        var result = await orderDetailQueryHandler.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        var result = await orderDetailByIdQueryHandler.Handle(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailCommand command)
    {
        var result = await createOrderDetailCommandHandler.Handle(command);
        return CreatedAtAction(nameof(GetOrderDetailById), new { id = result }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail([FromBody] UpdateOrderDetailCommand command)
    {
        await updateOrderDetailCommandHandler.Handle(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        await deleteOrderDetailCommandHandler.Handle(new(id));
        return NoContent();
    }
}