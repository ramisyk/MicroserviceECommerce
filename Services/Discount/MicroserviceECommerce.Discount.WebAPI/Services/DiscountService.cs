using Dapper;
using MicroserviceECommerce.Discount.WebAPI.Context;
using MicroserviceECommerce.Discount.WebAPI.Dtos.CouponDtos;

namespace MicroserviceECommerce.Discount.WebAPI.Services;

public class DiscountService(DapperContext context) : IDiscountService
{
    public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
    {
        string query = "SELECT * FROM Coupons;";
        using var connection = context.CreateConnection();
        var coupons = await connection.QueryAsync<ResultCouponDto>(query);
        return coupons.ToList();
    }

    public async Task<GetByIdCouponDto> GetCouponByIdAsync(int id)
    {
        string query = "SELECT * FROM Coupons WHERE CouponId = @CouponId;";
        var parameters = new DynamicParameters();
        parameters.Add("CouponId", id);
        using var connection = context.CreateConnection();
        var coupon = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
        return coupon;
    }

    public async Task CreateCouponAsync(CreateCouponDto couponDto)
    {
        string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate);";
        var parameters = new DynamicParameters();
        parameters.Add("Code", couponDto.Code);
        parameters.Add("Rate", couponDto.Rate);
        parameters.Add("IsActive", couponDto.IsActive);
        parameters.Add("ValidDate", couponDto.ValidDate);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task UpdateCouponAsync(UpdateCouponDto couponDto)
    {
        string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId;";
        var parameters = new DynamicParameters();
        parameters.Add("CouponId", couponDto.CouponId);
        parameters.Add("Code", couponDto.Code);
        parameters.Add("Rate", couponDto.Rate);
        parameters.Add("IsActive", couponDto.IsActive);
        parameters.Add("ValidDate", couponDto.ValidDate);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteCouponAsync(int id)
    {
        string query = "DELETE FROM Coupons WHERE CouponId = @CouponId;";
        var parameters = new DynamicParameters();
        parameters.Add("CouponId", id);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public int GetDiscountCouponCountRate(string code)
    {
        string query = "Select Rate From Coupons Where Code=@code";
        var parameters = new DynamicParameters();
        parameters.Add("@code", code);
        using (var connection = context.CreateConnection())
        {
            var value = connection.QueryFirstOrDefault<int>(query, parameters);
            return value;
        }
    }

    public async Task<int> GetDiscountCouponCount()
    {
        string query = "Select Count(*) From Coupons";
        using (var connection = context.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<int>(query);
            return values;
        }
    }
}