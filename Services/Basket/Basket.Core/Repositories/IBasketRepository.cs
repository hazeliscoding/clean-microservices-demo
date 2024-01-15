using Basket.Core.Entities;

namespace Basket.Core.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string username);
    Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);
    Task DeleteBasket(string username);
}~