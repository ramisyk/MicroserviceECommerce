using MicroserviceECommerce.Cargo.BusinessLayer.Abstract;
using MicroserviceECommerce.Cargo.DataAccessLayer.Abstract;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;

namespace MicroserviceECommerce.Cargo.BusinessLayer.Concrete;

public class CargoCustomerManager : ICargoCustomerService
{
    private readonly ICargoCustomerDal _cargoCustomerDal;
    public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
    {
        _cargoCustomerDal = cargoCustomerDal;
    }
    public void TDelete(int id)
    {
        _cargoCustomerDal.Delete(id);
    }
    public List<CargoCustomer> TGetAll()
    {
        return _cargoCustomerDal.GetAll();
    }
    public CargoCustomer TGetById(int id)
    {
        return _cargoCustomerDal.GetById(id);
    }

    public CargoCustomer TGetCargoCustomerById(string id)
    {
        return _cargoCustomerDal.GetCargoCustomerById(id);
    }

    public void TInsert(CargoCustomer entity)
    {
        _cargoCustomerDal.Insert(entity);
    }
    public void TUpdate(CargoCustomer entity)
    {
        _cargoCustomerDal.Update(entity);
    }
}