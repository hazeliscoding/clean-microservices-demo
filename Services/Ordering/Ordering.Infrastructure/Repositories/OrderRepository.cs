using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repositories;

public class OrderRepository(OrderContext dbContext) : RepositoryBase<Order>(dbContext)
{
    private readonly OrderContext _dbContext = dbContext;

    public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
    {
        var orderList = await _dbContext.Orders
            .Where(o => o.UserName == userName)
            .ToListAsync();
        return orderList;
    }
}