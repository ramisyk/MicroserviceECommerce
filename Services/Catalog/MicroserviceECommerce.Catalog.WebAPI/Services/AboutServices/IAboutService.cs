using MicroserviceECommerce.Catalog.WebAPI.Dtos.AboutDtos;

namespace MicroserviceECommerce.Catalog.WebAPI.Services.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutAsync();
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAboutAsync(string id);
    Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
}