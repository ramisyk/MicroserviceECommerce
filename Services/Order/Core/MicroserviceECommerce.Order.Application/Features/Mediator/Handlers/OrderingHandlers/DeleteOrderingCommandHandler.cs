using MediatR;
using MicroserviceECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
{
    private readonly IRepository<Ordering> _orderingRepository;

    public DeleteOrderingCommandHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
    {
        var ordering = await _orderingRepository.GetByIdAsync(request.Id);
        await _orderingRepository.DeleteAsync(ordering);
    }
}