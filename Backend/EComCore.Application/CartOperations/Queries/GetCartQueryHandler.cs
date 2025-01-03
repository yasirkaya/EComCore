using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.CartOperations.Queries
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto>
    {
        private readonly ICartQueryService _cartQueryService;

        public GetCartQueryHandler(ICartQueryService cartQueryService)
        {
            _cartQueryService = cartQueryService;
        }

        public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return await _cartQueryService.GetByUserIdAsync(request.UserId);
        }
    }
}