using MicroserviceECommerce.Catalog.WebAPI.Services.StatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Catalog.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController(IStatisticService statisticService) : ControllerBase
{
    [HttpGet("GetBrandCount")]
    public async Task<IActionResult> GetBrandCount()
    {
        var value = await statisticService.GetBrandCount();
        return Ok(value);
    }

    [HttpGet("GetCategoryCount")]
    public async Task<IActionResult> GetCategoryCount()
    {
        var value = await statisticService.GetCategoryCount();
        return Ok(value);
    }

    [HttpGet("GetProductCount")]
    public async Task<IActionResult> GetProductCount()
    {
        var value = await statisticService.GetProductCount();
        return Ok(value);
    }

    [HttpGet("GetProductAvgPrice")]
    public async Task<IActionResult> GetProductAvgPrice()
    {
        var value = await statisticService.GetProductAvgPrice();
        return Ok(value);
    }


    [HttpGet("GetMaxPriceProductName")]
    public async Task<IActionResult> GetMaxPriceProductName()
    {
        var value = await statisticService.GetMaxPriceProductName();
        return Ok(value);
    }

    [HttpGet("GetMinPriceProductName")]
    public async Task<IActionResult> GetMinPriceProductName()
    {
        var value = await statisticService.GetMinPriceProductName();
        return Ok(value);
    }
}
