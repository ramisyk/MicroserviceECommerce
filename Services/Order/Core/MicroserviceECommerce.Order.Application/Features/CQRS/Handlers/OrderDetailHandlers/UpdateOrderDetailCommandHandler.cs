using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(command.OrderDetailId);
        orderDetail.ProductId = command.ProductId;
        orderDetail.ProductName = command.ProductName;
        orderDetail.ProductPrice = command.ProductPrice;
        orderDetail.ProductAmount = command.ProductAmount;
        orderDetail.ProductTotalPrice = command.ProductTotalPrice;
        await _orderDetailRepository.UpdateAsync(orderDetail);
    }

}