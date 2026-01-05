using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;
using MicroserviceECommerce.Order.Persistence.Context;

namespace MicroserviceECommerce.Order.Persistence.Repositories;

public class OrderingRepository : IOrderingRepository
{
    private readonly OrderDbContext _orderContext;
    public OrderingRepository(OrderDbContext orderContext)
    {
        _orderContext = orderContext;
    }
    public List<Ordering> GetOrderingsByUserId(string id)
    {
        var values = _orderContext.Orderings.Where(x => x.UserId == id).ToList();
        return values;
    }
}