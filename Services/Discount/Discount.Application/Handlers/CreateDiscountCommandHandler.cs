using Discount.Application.Commands;
using Discount.Application.Mapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers;

public class CreateDiscountCommandHandler(IDiscountRepository discountRepository) : IRequestHandler<CreateDiscountCommand, CouponModel>
{

    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.Mapper.Map<Coupon>(request);
        await discountRepository.CreateDiscount(coupon);
        return DiscountMapper.Mapper.Map<CouponModel>(coupon);
    }
}