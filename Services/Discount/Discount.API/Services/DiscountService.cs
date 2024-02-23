using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.API.Services;

public class DiscountService(IMediator mediator, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var query = new GetDiscountQuery(request.ProductName);
        var result = await mediator.Send(query);
        logger.LogInformation("Discount is retrieved for ProductName : {ProductName}, Amount : {Amount}", result.ProductName, result.Amount);
        return result;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var cmd = new CreateDiscountCommand
        {
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description
        };

        var result = await mediator.Send(cmd);
        logger.LogInformation("Discount is successfully created for ProductName : {ProductName}", result.ProductName);
        return result;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var cmd = new UpdateDiscountCommand
        {
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description
        };

        var result = await mediator.Send(cmd);
        logger.LogInformation("Discount is successfully updated for ProductName : {ProductName}", result.ProductName);
        return result;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request,
        ServerCallContext context)
    {
        var cmd = new DeleteDiscountCommand(request.ProductName);
        var result = await mediator.Send(cmd);
        logger.LogInformation("Discount is successfully deleted for ProductName : {ProductName}", request.ProductName);
        return new DeleteDiscountResponse { Success = result };
    }
}