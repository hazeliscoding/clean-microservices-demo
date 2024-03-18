using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger logger)
    : IRequestHandler<CheckoutOrderCommand, int>
{
    public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = mapper.Map<Order>(request);
        var generatedOrder = await orderRepository.AddAsync(orderEntity);
        logger.LogInformation($"Order {generatedOrder.Id} is successfully created.");
        return generatedOrder.Id;
    }
}