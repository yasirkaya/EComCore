using MediatR;

namespace EComCore.Application.CartOperations.Commands
{
    public class RemoveFromCartCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}