using AutoMapper;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Application.Services.Commands;

public class CartCommandService : ICartCommandService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CartCommandService(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<int> AddToCartAsync(AddToCartDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.ProductId);
        await product.EnsureNotNullAsync(message: $"Product not found with id {dto.ProductId}");

        var cart = await _cartRepository.GetByUserIdAsync(dto.UserId);
        if (cart == null)
        {
            cart = new Cart { UserId = dto.UserId, CreatedAt = DateTime.UtcNow };
            await _cartRepository.AddAsync(cart);
        }

        var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
        if (cartItem == null)
        {
            cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                UnitPrice = product.Price,
                CreatedAt = DateTime.UtcNow
            };
            cart.Items.Add(cartItem);
        }
        else
        {
            cartItem.Quantity += dto.Quantity;
            cartItem.UpdatedAt = DateTime.UtcNow;
        }

        await _cartRepository.UpdateAsync(cart);
        return cart.Id;
    }

    public async Task UpdateCartItemAsync(UpdateCartItemDto dto)
    {
        var cart = await _cartRepository.GetByUserIdAsync(dto.UserId);
        await cart.EnsureNotNullAsync(message: $"Cart not found for user {dto.UserId}");

        var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
        await cartItem.EnsureNotNullAsync(message: $"Cart item not found for product {dto.ProductId}");

        cartItem.Quantity = dto.Quantity;
        cartItem.UpdatedAt = DateTime.UtcNow;
        await _cartRepository.UpdateAsync(cart);
    }

    public async Task RemoveFromCartAsync(int userId, int productId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);
        await cart.EnsureNotNullAsync(message: $"Cart not found for user {userId}");

        var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        await cartItem.EnsureNotNullAsync(message: $"Cart item not found for product {productId}");

        cart.Items.Remove(cartItem);
        await _cartRepository.UpdateAsync(cart);
    }
}