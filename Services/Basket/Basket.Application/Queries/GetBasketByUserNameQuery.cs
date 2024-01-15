using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public class GetBasketByUserNameQuery(string userName) : IRequest<ShoppingCartResponse>
{
    public string UserName { get; set; } = userName;
}