using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class DeleteProductByIdHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductByIdQuery, bool>
{
    public async Task<bool> Handle(DeleteProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await productRepository.DeleteProduct(request.Id);
    }
}