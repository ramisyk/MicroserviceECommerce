using MediatR;
using MicroserviceECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Domain.Entities;

namespace MicroserviceECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IRepository<Ordering> _orderingRepository;

    public GetOrderingByIdQueryHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var ordering = await _orderingRepository.GetByIdAsync(request.Id);
        return new()
        {
            OrderingId = ordering.OrderingId,
            UserId = ordering.UserId,
            TotalPrice = ordering.TotalPrice,
            OrderDate = ordering.OrderDate
        };
    }
}