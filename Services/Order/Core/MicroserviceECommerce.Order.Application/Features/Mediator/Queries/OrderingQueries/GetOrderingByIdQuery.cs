using MediatR;
using MicroserviceECommerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MicroserviceECommerce.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MicroserviceECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
{
    public int Id { get; set; }
    public GetOrderingByIdQuery(int id)
    {
        Id = id;
    }
}