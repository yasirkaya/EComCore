using MediatR;

namespace EComCore.Application.CartOperations.Commands;

public class RemoveFromCartCommand : IRequest
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}