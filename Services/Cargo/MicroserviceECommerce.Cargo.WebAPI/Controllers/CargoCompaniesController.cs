using MicroserviceECommerce.Cargo.BusinessLayer.Abstract;
using MicroserviceECommerce.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Cargo.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController(ICargoCompanyService cargoCompanyService) : ControllerBase
{
    [HttpGet]
    public IActionResult CargoCompanyList()
    {
        var values = cargoCompanyService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyName = createCargoCompanyDto.CargoCompanyName
        };
        cargoCompanyService.TInsert(cargoCompany);
        return Ok("Kargo Şirketi Başarıyla Oluşturuldu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCompany(int id)
    {
        cargoCompanyService.TDelete(id);
        return Ok("Kargo Şirketi Başarıyla Silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCompanyById(int id)
    {
        var values = cargoCompanyService.TGetById(id);
        return Ok(values);
    }

    [HttpPut]
    public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
            CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
        };
        cargoCompanyService.TUpdate(cargoCompany);
        return Ok("Kargo Şirketi Başarıyla Güncellendi");
    }
}