using Discount.Application.Mapper;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class GetDiscountQueryHandler(IDiscountRepository discountRepository)
    : IRequestHandler<GetDiscountQuery, CouponModel>
{
    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await discountRepository.GetDiscount(request.ProductName);
        if (coupon == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with the product name = {request.ProductName} not found"));
        }

        var couponResponse = DiscountMapper.Mapper.Map<CouponModel>(coupon);
        return couponResponse;
    }
}