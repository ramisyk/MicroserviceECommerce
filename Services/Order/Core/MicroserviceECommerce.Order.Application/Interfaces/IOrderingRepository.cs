using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Interfaces;

public interface IOrderingRepository
{
    public List<Ordering> GetOrderingsByUserId(string id);

}