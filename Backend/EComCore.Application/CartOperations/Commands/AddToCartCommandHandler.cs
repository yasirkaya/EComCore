using System;
using System.Threading;
using System.Threading.Tasks;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using MediatR;

namespace EComCore.Application.CartOperations.Commands
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, bool>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public AddToCartCommandHandler(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                throw new Exception("Ürün bulunamadı");

            var cart = await _cartRepository.GetActiveCartByUserIdAsync(request.UserId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = request.UserId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                };
                await _cartRepository.AddAsync(cart);
            }

            var cartItem = new CartItem
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = product.Price
            };

            return await _cartRepository.AddItemToCartAsync(cart.Id, cartItem);
        }
    }
}