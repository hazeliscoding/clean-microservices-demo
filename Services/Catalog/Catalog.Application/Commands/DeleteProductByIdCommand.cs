using MediatR;

namespace Catalog.Application.Commands;

public class DeleteProductByIdCommand(string id) : IRequest<bool>
{
    public string Id { get; set; } = id;
}