using System.Threading;
using System.Threading.Tasks;
using EComCore.Domain.DTOs.OrderDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.OrderOperations.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderCommandService _orderCommandService;

        public CreateOrderCommandHandler(IOrderCommandService orderCommandService)
        {
            _orderCommandService = orderCommandService;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderCommandService.CreateOrderAsync(request.CreateOrderDto);
        }
    }
}