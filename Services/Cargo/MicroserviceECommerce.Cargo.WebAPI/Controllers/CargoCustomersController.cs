using MicroserviceECommerce.Cargo.BusinessLayer.Abstract;
using MicroserviceECommerce.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Cargo.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController(ICargoCustomerService cargoCustomerService) : ControllerBase
{
    [HttpGet]
    public IActionResult CargoCustomerList()
    {
        var values = cargoCustomerService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCustomerById(int id)
    {
        var value = cargoCustomerService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            Address = createCargoCustomerDto.Address,
            City = createCargoCustomerDto.City,
            District = createCargoCustomerDto.District,
            Email = createCargoCustomerDto.Email,
            Name = createCargoCustomerDto.Name,
            Phone = createCargoCustomerDto.Phone,
            Surname = createCargoCustomerDto.Surname,
            //UserCustomerId = createCargoCustomerDto.UserCustomerId
        };
        cargoCustomerService.TInsert(cargoCustomer);
        return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Yapıldı");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCustomer(int id)
    {
        cargoCustomerService.TDelete(id);
        return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
    }

    [HttpPut]
    public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            Address = updateCargoCustomerDto.Address,
            CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
            City = updateCargoCustomerDto.City,
            District = updateCargoCustomerDto.District,
            Email = updateCargoCustomerDto.Email,
            Name = updateCargoCustomerDto.Name,
            Phone = updateCargoCustomerDto.Phone,
            Surname = updateCargoCustomerDto.Surname,
            //UserCustomerId = updateCargoCustomerDto.UserCustomerId
        };
        cargoCustomerService.TUpdate(cargoCustomer);
        return Ok("Kargo Müşteri Güncelleme İşlemi Başarıyla Yapıldı");
    }

    //[HttpGet("GetCargoCustomerById")]
    //public IActionResult GetCargoCustomerById(string id)
    //{
    //    return Ok(_cargoCustomerService.TGetCargoCustomerById(id));
    //}
}