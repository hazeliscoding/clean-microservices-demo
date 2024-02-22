using Discount.Application.Commands;
using Discount.Application.Mapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers;

public class UpdateDiscountCommandHandler(IDiscountRepository discountRepository) : IRequestHandler<UpdateDiscountCommand, CouponModel>
{
    public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.Mapper.Map<Coupon>(request);
        await discountRepository.UpdateDiscount(coupon);
        return DiscountMapper.Mapper.Map<CouponModel>(coupon);
    }
}