using MediatR;
using MicroserviceECommerce.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MicroserviceECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
{
    
}