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
        public CartRepository(EComCoreDbContext context) : base(context)
        {
        }

        public async Task ClearCartAsync(int userId)
        {
            await _context.CartItems
                .Where(ci => ci.Cart.UserId == userId)
                .ForEachAsync(ci => _context.CartItems.Remove(ci));

            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetByUserIdAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}