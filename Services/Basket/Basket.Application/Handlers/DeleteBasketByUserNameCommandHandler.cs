using Basket.Application.Commands;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class DeleteBasketByUserNameCommandHandler(IBasketRepository basketRepository) : IRequestHandler<DeleteBasketByUserNameCommand, Unit>
{
    public async Task<Unit> Handle(DeleteBasketByUserNameCommand request, CancellationToken cancellationToken)
    {
        await basketRepository.DeleteBasket(request.UserName);
        return Unit.Value;
    }
}