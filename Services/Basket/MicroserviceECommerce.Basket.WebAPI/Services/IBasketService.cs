using MicroserviceECommerce.Basket.WebAPI.Dtos;

namespace MicroserviceECommerce.Basket.WebAPI.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket(string userId);
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task DeleteBasket(string userId);
}