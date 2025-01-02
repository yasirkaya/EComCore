using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Domain.Repositories;
using MediatR;

namespace EComCore.Application.CartOperations.Queries
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetActiveCartByUserIdAsync(request.UserId);
            if (cart == null)
                return null;

            var cartDto = new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                CreatedAt = cart.CreatedAt,
                UpdatedAt = cart.UpdatedAt,
                IsActive = cart.IsActive,
                Items = cart.CartItems.Select(ci => new CartItemDto
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.UnitPrice,
                    TotalPrice = ci.UnitPrice * ci.Quantity
                }).ToList(),
                TotalAmount = cart.CartItems.Sum(ci => ci.UnitPrice * ci.Quantity)
            };

            return cartDto;
        }
    }
}