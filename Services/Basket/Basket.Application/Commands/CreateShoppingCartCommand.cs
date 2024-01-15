using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands;

public class CreateShoppingCartCommand(string userName, List<ShoppingCartItem> items) : IRequest<ShoppingCartResponse>
{
    public string UserName { get; set; } = userName;
    public List<ShoppingCartItem> Items { get; set; } = items;
}