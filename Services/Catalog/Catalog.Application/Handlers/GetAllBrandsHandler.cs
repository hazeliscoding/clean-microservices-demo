using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllBrandsHandler(IBrandRepository brandRepository, IMapper mapper)
    : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository = brandRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brandList = await brandRepository.GetAllBrands();
        var brandResponseList = _mapper.Map<IList<BrandResponse>>(brandList);
        return brandResponseList;
    }
}