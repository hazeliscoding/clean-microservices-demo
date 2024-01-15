using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class DeleteProductByIdHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductByIdCommand, bool>
{
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        return await productRepository.DeleteProduct(request.Id);
    }
}