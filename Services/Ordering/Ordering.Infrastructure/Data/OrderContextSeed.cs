using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation($"Ordering Database seeded: {nameof(OrderContext)}");
        }
    }

    private static IEnumerable<Order> GetOrders()
    {
        return new List<Order>
        {
            new()
            {
                UserName = "JohnDoe",
                TotalPrice = 100.00m,
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "johndoe@example.com",
                AddressLine = "123 Main St",
                Country = "USA",
                State = "California",
                ZipCode = "12345",
                CardName = "John Doe",
                CardNumber = "1234567890123456",
                Expiration = "12/23",
                Cvv = "123",
                PaymentMethod = 1
            },
            new()
            {
                UserName = "JaneSmith",
                TotalPrice = 200.00m,
                FirstName = "Jane",
                LastName = "Smith",
                EmailAddress = "janesmith@example.com",
                AddressLine = "456 Elm St",
                Country = "USA",
                State = "New York",
                ZipCode = "67890",
                CardName = "Jane Smith",
                CardNumber = "9876543210987654",
                Expiration = "11/24",
                Cvv = "456",
                PaymentMethod = 2
            }
        };
    }
}