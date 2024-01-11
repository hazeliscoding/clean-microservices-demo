using MediatR;

namespace Catalog.Application.Queries;

public class DeleteProductByIdQuery(string id) : IRequest<bool>
{
    public string Id { get; set; } = id;
}