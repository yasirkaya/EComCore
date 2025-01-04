using EComCore.Domain.DTOs.OrderDTO;
using MediatR;

namespace EComCore.Application.OrderOperations.Commands
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        public CreateOrderCommand(CreateOrderDto createOrderDto)
        {
            CreateOrderDto = createOrderDto;
        }
        public CreateOrderDto CreateOrderDto { get; set; }

    }
}