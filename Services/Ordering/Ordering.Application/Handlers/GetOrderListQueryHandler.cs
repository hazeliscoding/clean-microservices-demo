using AutoMapper;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetOrderListQuery, List<OrderResponse>>
{
    public async Task<List<OrderResponse>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var orderList = await orderRepository.GetOrdersByUserName(request.UserName);
        return mapper.Map<List<OrderResponse>>(orderList);
    }
}