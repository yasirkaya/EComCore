using MediatR;

namespace EComCore.Application.OrderOperations.Commands
{
    public class CancelOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }

        public CancelOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}