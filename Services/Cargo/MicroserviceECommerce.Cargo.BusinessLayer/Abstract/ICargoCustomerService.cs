using MicroserviceECommerce.Cargo.EntityLayer.Concrete;

namespace MicroserviceECommerce.Cargo.BusinessLayer.Abstract;

public interface ICargoCustomerService : IGenericService<CargoCustomer>
{
    CargoCustomer TGetCargoCustomerById(string id);
}