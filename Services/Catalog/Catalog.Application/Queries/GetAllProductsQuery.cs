using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllProductsQuery(CatalogSpecParams catalogSpecParams) : IRequest<Pagination<ProductResponse>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; } = catalogSpecParams;
}