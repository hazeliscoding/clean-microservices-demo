using MediatR;

namespace Basket.Application.Commands;

public class DeleteBasketByUserNameCommand(string userName) :IRequest<Unit>
{
    public string UserName { get; set; } = userName;
}