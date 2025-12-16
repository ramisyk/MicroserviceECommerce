using MicroserviceECommerce.Cargo.DataAccessLayer.Abstract;
using MicroserviceECommerce.Cargo.DataAccessLayer.Concrete;
using MicroserviceECommerce.Cargo.DataAccessLayer.Repositories;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;

namespace MicroserviceECommerce.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
{
    public EfCargoDetailDal(CargoContext context) : base(context)
    {
    }
}