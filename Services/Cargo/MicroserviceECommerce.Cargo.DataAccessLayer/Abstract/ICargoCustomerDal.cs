using MicroserviceECommerce.Cargo.EntityLayer.Concrete;

namespace MicroserviceECommerce.Cargo.DataAccessLayer.Abstract;

public interface ICargoCustomerDal : IGenericDal<CargoCustomer>
{
    CargoCustomer GetCargoCustomerById(string id);
}