using MicroserviceECommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using MicroserviceECommerce.Order.Application.Features.CQRS.Results.AddressResults;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IRepository<Address> _addressRepository;

    public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
    {
        var address = await _addressRepository.GetByIdAsync(query.Id);
        return new()
        {
            AddressId = address.AddressId,
            UserId = address.UserId,
            District = address.District,
            City = address.City,
            Detail = address.Detail
        };
    }
}