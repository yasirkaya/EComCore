using System.Threading;
using System.Threading.Tasks;
using EComCore.Domain.DTOs.OrderDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.OrderOperations.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderQueryService _orderQueryService;

        public GetOrderByIdQueryHandler(IOrderQueryService orderQueryService)
        {
            _orderQueryService = orderQueryService;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderQueryService.GetOrderByIdAsync(request.OrderId);
        }
    }
}