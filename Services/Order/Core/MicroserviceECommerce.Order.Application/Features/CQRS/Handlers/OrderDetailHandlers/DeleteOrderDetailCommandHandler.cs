using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class DeleteOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task Handle(DeleteOrderDetailCommand command)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(command.Id);
        await _orderDetailRepository.DeleteAsync(orderDetail);
    }

}