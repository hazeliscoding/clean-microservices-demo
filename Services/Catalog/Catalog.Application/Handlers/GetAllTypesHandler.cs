using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllTypesHandler(ITypesRepository typesRepository) : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
{
    public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        var typesList = await typesRepository.GetAllTypes();
        var typesResponse = ProductMapper.Mapper.Map<IList<TypesResponse>>(typesList);
        return typesResponse;
    }
}