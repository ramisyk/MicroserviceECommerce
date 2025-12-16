using MicroserviceECommerce.Cargo.DataAccessLayer.Abstract;
using MicroserviceECommerce.Cargo.DataAccessLayer.Concrete;
using MicroserviceECommerce.Cargo.DataAccessLayer.Repositories;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;

namespace MicroserviceECommerce.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
{
    public EfCargoCompanyDal(CargoContext context) : base(context)
    {
    }
}