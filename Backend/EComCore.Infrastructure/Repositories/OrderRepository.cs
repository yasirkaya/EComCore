using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComCore.Domain.Entities;
using EComCore.Domain.Enums;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EComCoreDbContext context) : base(context)
        {
        }

        public override async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<List<Order>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Order>> GetByStatusAsync(OrderStatus status)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.OrderStatus == status)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Orders.CountAsync(o => !o.IsDeleted);
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _context.Orders
                .Where(o => !o.IsDeleted && o.OrderStatus == OrderStatus.Completed)
                .SumAsync(o => o.TotalAmount);
        }

        public async Task<int> GetPendingOrdersCountAsync()
        {
            return await _context.Orders
                .CountAsync(o => !o.IsDeleted && o.OrderStatus == OrderStatus.Pending);
        }

        public async Task<decimal> GetAverageOrderValueAsync()
        {
            var completedOrders = await _context.Orders
                .Where(o => !o.IsDeleted && o.OrderStatus == OrderStatus.Completed)
                .ToListAsync();

            if (!completedOrders.Any()) return 0;

            return completedOrders.Average(o => o.TotalAmount);
        }

        public async Task<decimal> GetRevenueByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Where(o => !o.IsDeleted &&
                           o.OrderStatus == OrderStatus.Completed &&
                           o.CreatedAt >= startDate &&
                           o.CreatedAt <= endDate)
                .SumAsync(o => o.TotalAmount);
        }

        public async Task<IEnumerable<Order>> GetRecentOrdersAsync(int count)
        {
            return await _context.Orders
                .Include(o => o.User)
                .Where(o => !o.IsDeleted)
                .OrderByDescending(o => o.CreatedAt)
                .Take(count)
                .ToListAsync();
        }
    }
}