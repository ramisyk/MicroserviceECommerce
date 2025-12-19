using MicroserviceECommerce.Catalog.WebAPI.Dtos.ContactDtos;

namespace MicroserviceECommerce.Catalog.WebAPI.Services.ContactServices;

public interface IContactService
{
    Task<List<ResultContactDto>> GetAllContactAsync();
    Task CreateContactAsync(CreateContactDto createContactDto);
    Task UpdateContactAsync(UpdateContactDto updateContactDto);
    Task DeleteContactAsync(string id);
    Task<GetByIdContactDto> GetByIdContactAsync(string id);
}