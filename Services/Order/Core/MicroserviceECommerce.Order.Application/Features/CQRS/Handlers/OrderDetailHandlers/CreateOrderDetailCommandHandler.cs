using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<int> Handle(CreateOrderDetailCommand command)
    {
        var newOrderDetail = new OrderDetail()
        {
            ProductId = command.ProductId,
            ProductName = command.ProductName,
            ProductPrice = command.ProductPrice,
            ProductAmount = command.ProductAmount,
            ProductTotalPrice = command.ProductTotalPrice,
            OrderingId = command.OrderingId
        };

        await _orderDetailRepository.CreateAsync(newOrderDetail);

        return newOrderDetail.OrderDetailId;
    }

}