using MediatR;
using MicroserviceECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceECommerce.Order.Application.Interfaces;

namespace MicroserviceECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
{
    private readonly IOrderingRepository _orderingRepository;
    public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }
    public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
    {
        var values = _orderingRepository.GetOrderingsByUserId(request.Id);
        return values.Select(x => new GetOrderingByUserIdQueryResult
        {
            OrderDate = x.OrderDate,
            OrderingId = x.OrderingId,
            TotalPrice = x.TotalPrice,
            UserId = x.UserId
        }).ToList();
    }
}