using System;
using System.Threading.Tasks;
using EComCore.Application.CartOperations.Queries;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.Services.Queries
{
    public class CartQueryService : ICartQueryService
    {
        private readonly IMediator _mediator;

        public CartQueryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CartDto> GetCartAsync(int userId)
        {
            var query = new GetCartQuery { UserId = userId };
            return await _mediator.Send(query);
        }
    }
}