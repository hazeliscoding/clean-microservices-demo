using Discount.Grpc.Protos;

namespace Basket.Application.GrpcService;

public class DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
{
    public async Task<CouponModel> GetDiscount(string productName)
    {
        var discountRequest = new GetDiscountRequest { ProductName = productName };
        return await discountProtoServiceClient.GetDiscountAsync(discountRequest);
    }
}