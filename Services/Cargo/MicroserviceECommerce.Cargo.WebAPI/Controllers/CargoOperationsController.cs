using MicroserviceECommerce.Cargo.BusinessLayer.Abstract;
using MicroserviceECommerce.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Cargo.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController(ICargoOperationService cargoOperationService) : ControllerBase
{
    [HttpGet]
    public IActionResult CargoOperationList()
    {
        var values = cargoOperationService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
    {
        CargoOperation CargoOperation = new CargoOperation()
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OperationDate = createCargoOperationDto.OperationDate
        };
        cargoOperationService.TInsert(CargoOperation);
        return Ok("Kargo İşlemi Başarıyla Oluşturuldu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoOperation(int id)
    {
        cargoOperationService.TDelete(id);
        return Ok("Kargo İşlemi Başarıyla Silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoOperationById(int id)
    {
        var values = cargoOperationService.TGetById(id);
        return Ok(values);
    }

    [HttpPut]
    public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
    {
        CargoOperation CargoOperation = new CargoOperation()
        {
            Barcode = updateCargoOperationDto.Barcode,
            CargoOperationId = updateCargoOperationDto.CargoOperationId,
            Description = updateCargoOperationDto.Description,
            OperationDate = updateCargoOperationDto.OperationDate
        };
        cargoOperationService.TUpdate(CargoOperation);
        return Ok("Kargo İşlemi Başarıyla Güncellendi");
    }
}