using System;
using System.Threading.Tasks;
using EComCore.Application.CartOperations.Commands;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.Services.Commands
{
    public class CartCommandService : ICartCommandService
    {
        private readonly IMediator _mediator;

        public CartCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> AddToCartAsync(int userId, int productId, int quantity)
        {
            var command = new AddToCartCommand
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            };

            return await _mediator.Send(command);
        }

        public async Task<bool> UpdateCartItemAsync(int userId, int productId, int quantity)
        {
            var command = new UpdateCartItemCommand
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            };

            return await _mediator.Send(command);
        }

        public async Task<bool> RemoveFromCartAsync(int userId, int productId)
        {
            var command = new RemoveFromCartCommand
            {
                UserId = userId,
                ProductId = productId
            };

            return await _mediator.Send(command);
        }
    }
}