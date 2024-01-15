using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllProductsHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, Pagination<ProductResponse>>
{
    
    public async Task<Pagination<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await productRepository.GetProducts(request.CatalogSpecParams);
        var productResponseList = ProductMapper.Mapper.Map<Pagination<ProductResponse>>(productList);
        return productResponseList;
    }
}