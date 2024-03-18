using MediatR;

namespace Ordering.Application.Commands;

public class DeleteOrderCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}