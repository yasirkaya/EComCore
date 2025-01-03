using MediatR;

namespace EComCore.Application.CartOperations.Commands;

public class AddToCartCommand : IRequest<int>
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}