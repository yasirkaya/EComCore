using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly EComCoreDbContext _context;

        public CartRepository(EComCoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cart> GetActiveCartByUserIdAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive);
        }

        public async Task<bool> AddItemToCartAsync(int cartId, CartItem item)
        {
            var cart = await GetByIdAsync(cartId);
            if (cart == null) return false;

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
                _context.Update(existingItem);
            }
            else
            {
                item.CartId = cartId;
                item.CreatedAt = DateTime.UtcNow;
                item.UpdatedAt = DateTime.UtcNow;
                await _context.CartItems.AddAsync(item);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItemFromCartAsync(int cartId, int productId)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);

            if (cartItem == null) return false;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateItemQuantityAsync(int cartId, int productId, int quantity)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);

            if (cartItem == null) return false;

            cartItem.Quantity = quantity;
            cartItem.UpdatedAt = DateTime.UtcNow;

            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId)
        {
            return await _context.CartItems
                .Include(ci => ci.Product)
                .Where(ci => ci.CartId == cartId)
                .ToListAsync();
        }
    }
}