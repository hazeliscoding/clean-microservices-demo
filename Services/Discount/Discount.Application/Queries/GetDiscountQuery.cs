using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Queries;

public class GetDiscountQuery(string productName) : IRequest<CouponModel>
{
    public string ProductName { get; set; } = productName;
}