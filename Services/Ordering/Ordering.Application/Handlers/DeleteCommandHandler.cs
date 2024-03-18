using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Application.Extensions;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class DeleteCommandHandler(
    IOrderRepository orderRepository,
    ILogger<DeleteCommandHandler> logger) : IRequestHandler<DeleteOrderCommand, Unit>
{
    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await orderRepository.GetByIdAsync(request.Id);
        if (orderToDelete == null)
        {
            logger.LogError("Order not found");
            throw new OrderNotFoundException(nameof(Order), request.Id);
        }
        
        await orderRepository.DeleteAsync(orderToDelete);
        
        logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");
        return Unit.Value;
    }
}