using Discount.Core.Entities;

namespace Discount.Core.Repositories;

public interface IDiscountRepository
{
    Task<Coupon> GetDiscount(string productName);
    Task<Coupon> CreateDiscount(Coupon coupon);
    Task<Coupon> UpdateDiscount(Coupon coupon);
    Task<Coupon> DeleteDiscount(string productName);
}