using MediatR;

namespace EComCore.Application.CartOperations.Commands;

public class ClearCartCommand : IRequest
{
    public int UserId { get; set; }
}