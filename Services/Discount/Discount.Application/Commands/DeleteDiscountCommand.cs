using MediatR;

namespace Discount.Application.Commands;

public class DeleteDiscountCommand(string productName) : IRequest<bool>
{
    public string ProductName { get; set; } = productName;
}