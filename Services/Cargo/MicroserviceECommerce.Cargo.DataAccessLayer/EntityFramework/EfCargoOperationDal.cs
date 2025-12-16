using MicroserviceECommerce.Cargo.DataAccessLayer.Abstract;
using MicroserviceECommerce.Cargo.DataAccessLayer.Concrete;
using MicroserviceECommerce.Cargo.DataAccessLayer.Repositories;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;

namespace MicroserviceECommerce.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
{
    public EfCargoOperationDal(CargoContext context) : base(context)
    {
    }
}