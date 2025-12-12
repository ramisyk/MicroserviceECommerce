using MediatR;
using MicroserviceECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _orderingRepository;

    public UpdateOrderingCommandHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var ordering = await _orderingRepository.GetByIdAsync(request.OrderingId);
        ordering.UserId = request.UserId;
        ordering.OrderDate = request.OrderDate;
        ordering.TotalPrice = request.TotalPrice;
        await _orderingRepository.UpdateAsync(ordering);
    }
}