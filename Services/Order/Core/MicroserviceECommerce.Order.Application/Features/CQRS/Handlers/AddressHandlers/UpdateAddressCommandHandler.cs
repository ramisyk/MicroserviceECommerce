using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(UpdateAddressCommand updatedAddress)
    {
        var address = await _addressRepository.GetByIdAsync(updatedAddress.AddressId);
        address.UserId = updatedAddress.UserId;
        address.District = updatedAddress.District;
        address.City = updatedAddress.City;
        address.Detail = updatedAddress.Detail;
        await _addressRepository.UpdateAsync(address);
    }
}