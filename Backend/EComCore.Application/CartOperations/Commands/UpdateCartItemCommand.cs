using MediatR;

namespace EComCore.Application.CartOperations.Commands;

public class UpdateCartItemCommand : IRequest
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}