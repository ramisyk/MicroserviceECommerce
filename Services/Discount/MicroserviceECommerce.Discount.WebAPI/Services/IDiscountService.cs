using MicroserviceECommerce.Discount.WebAPI.Dtos.CouponDtos;

namespace MicroserviceECommerce.Discount.WebAPI.Services;

public interface IDiscountService
{
    Task<List<ResultCouponDto>> GetAllCouponsAsync();
    Task<GetByIdCouponDto> GetCouponByIdAsync(int id);
    Task CreateCouponAsync(CreateCouponDto couponDto);
    Task UpdateCouponAsync(UpdateCouponDto couponDto);
    Task DeleteCouponAsync(int id);
}