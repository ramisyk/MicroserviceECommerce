using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public CreateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<int> Handle(CreateAddressCommand request)
    {
        Address newAddress = new()
        {
            UserId = request.UserId,
            District = request.District,
            City = request.City,
            Detail = request.Detail
        };
        await _addressRepository.CreateAsync(newAddress);
        return newAddress.AddressId;
    }
}