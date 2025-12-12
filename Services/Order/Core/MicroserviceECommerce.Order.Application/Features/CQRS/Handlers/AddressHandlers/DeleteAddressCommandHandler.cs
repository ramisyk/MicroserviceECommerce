using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class DeleteAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public DeleteAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(DeleteAddressCommand command)
    {
        var address = await _addressRepository.GetByIdAsync(command.Id);
        await _addressRepository.DeleteAsync(address);
    }
}