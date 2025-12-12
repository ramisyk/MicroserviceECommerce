using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _orderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _orderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler orderDetailQueryHandler,
            GetOrderDetailByIdQueryHandler orderDetailByIdQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
            UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler,
            DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler)
        {
            _orderDetailQueryHandler = orderDetailQueryHandler;
            _orderDetailByIdQueryHandler = orderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var result = await _orderDetailQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var result = await _orderDetailByIdQueryHandler.Handle(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailCommand command)
        {
            var result = await _createOrderDetailCommandHandler.Handle(command);
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = result }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail([FromBody] UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _deleteOrderDetailCommandHandler.Handle(new(id));
            return NoContent();
        }
    }
}
