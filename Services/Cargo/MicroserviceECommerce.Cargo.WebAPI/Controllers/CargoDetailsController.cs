using MicroserviceECommerce.Cargo.BusinessLayer.Abstract;
using MicroserviceECommerce.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MicroserviceECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Cargo.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController(ICargoDetailService cargoDetailService) : ControllerBase
{
    [HttpGet]
    public IActionResult CargoDetailList()
    {
        var values = cargoDetailService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        CargoDetail CargoDetail = new CargoDetail()
        {
            Barcode = createCargoDetailDto.Barcode,
            CargoCompanyId = createCargoDetailDto.CargoCompanyId,
            ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
            SenderCustomer = createCargoDetailDto.SenderCustomer
        };
        cargoDetailService.TInsert(CargoDetail);
        return Ok("Kargo Detayları Başarıyla Oluşturuldu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoDetail(int id)
    {
        cargoDetailService.TDelete(id);
        return Ok("Kargo Detayları Başarıyla Silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoDetailById(int id)
    {
        var values = cargoDetailService.TGetById(id);
        return Ok(values);
    }

    [HttpPut]
    public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        CargoDetail CargoDetail = new CargoDetail()
        {
            Barcode = updateCargoDetailDto.Barcode,
            CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
            CargoDetailId = updateCargoDetailDto.CargoDetailId,
            ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
            SenderCustomer = updateCargoDetailDto.SenderCustomer

        };
        cargoDetailService.TUpdate(CargoDetail);
        return Ok("Kargo Detayları Başarıyla Güncellendi");
    }
}