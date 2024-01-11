using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductByIdQuery(string id) : IRequest<ProductResponse>
{
    public string Id { get; set; } = id;
}