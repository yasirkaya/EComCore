using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EComCore.Domain.DTOs.OrderDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.OrderOperations.Queries
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderQueryService _orderQueryService;

        public GetOrdersQueryHandler(IOrderQueryService orderQueryService)
        {
            _orderQueryService = orderQueryService;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderQueryService.GetUserOrdersAsync(request.UserId);
        }
    }
}