using EComCore.Domain.DTOs.OrderDTO;
using MediatR;

namespace EComCore.Application.OrderOperations.Commands
{
    public class UpdateOrderStatusCommand : IRequest<OrderDto>
    {
        public UpdateOrderStatusDto UpdateOrderStatusDto { get; set; }

        public UpdateOrderStatusCommand(UpdateOrderStatusDto updateOrderStatusDto)
        {
            UpdateOrderStatusDto = updateOrderStatusDto;
        }
    }
}