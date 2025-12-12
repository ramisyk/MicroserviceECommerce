using MicroserviceECommerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(int id)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
        return new()
        {
            OrderDetailId = orderDetail.OrderDetailId,
            ProductId = orderDetail.ProductId,
            ProductName = orderDetail.ProductName,
            ProductPrice = orderDetail.ProductPrice,
            ProductAmount = orderDetail.ProductAmount,
            ProductTotalPrice = orderDetail.ProductTotalPrice,
            OrderingId = orderDetail.OrderingId
        };
    }
}