using MicroserviceECommerce.Cargo.DataAccessLayer.Abstract;
using MicroserviceECommerce.Cargo.DataAccessLayer.Concrete;
using MicroserviceECommerce.Cargo.DataAccessLayer.Repositories;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;

namespace MicroserviceECommerce.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
{
    private readonly CargoContext _cargoContext;
    public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
    {
        _cargoContext = cargoContext;
    }
    public CargoCustomer GetCargoCustomerById(string id)
    {
        var value = _cargoContext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
        return value;
    }
}