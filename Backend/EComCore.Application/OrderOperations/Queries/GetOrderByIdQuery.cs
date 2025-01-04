using EComCore.Domain.DTOs.OrderDTO;
using MediatR;

namespace EComCore.Application.OrderOperations.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int OrderId { get; set; }

        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}