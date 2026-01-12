using MicroserviceECommerce.Discount.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Discount.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCoupons()
    {
        var values = await _discountService.GetAllCouponsAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCouponById(int id)
    {
        var value = await _discountService.GetCouponByIdAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoupon([FromBody] Dtos.CouponDtos.CreateCouponDto couponDto)
    {
        await _discountService.CreateCouponAsync(couponDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCoupon([FromBody] Dtos.CouponDtos.UpdateCouponDto couponDto)
    {
        await _discountService.UpdateCouponAsync(couponDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        await _discountService.DeleteCouponAsync(id);
        return Ok();
    }

    [HttpGet("GetDiscountCouponCountRate")]
    public IActionResult GetDiscountCouponCountRate(string code)
    {
        var values = _discountService.GetDiscountCouponCountRate(code);
        return Ok(values);
    }

    [HttpGet("GetDiscountCouponCount")]
    public async Task<IActionResult> GetDiscountCouponCount()
    {
        var values = await _discountService.GetDiscountCouponCount();
        return Ok(values);
    }
}