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

        public async Task<Cart> GetByUserIdAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}