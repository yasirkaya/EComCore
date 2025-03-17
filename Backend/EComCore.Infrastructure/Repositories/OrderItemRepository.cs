using EComCore.Domain.Entities;
using EComCore.Domain.Enums;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(EComCoreDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId)
    {
        return await _context.OrderItems
            .Include(oi => oi.Product)
            .Where(oi => oi.OrderId == orderId)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetByProductIdAsync(int productId)
    {
        return await _context.OrderItems
            .Include(oi => oi.Order)
            .Where(oi => oi.ProductId == productId)
            .ToListAsync();
    }

    public async Task<IEnumerable<RevenueByCategory>> GetRevenueByCategoryAsync()
    {
        return await _context.OrderItems
            .Include(oi => oi.Product)
            .ThenInclude(p => p.ProductToCategories)
            .ThenInclude(ptc => ptc.Category)
            .Include(oi => oi.Order)
            .Where(oi => oi.Order.OrderStatus == OrderStatus.Completed)
            .GroupBy(oi => oi.Product.ProductToCategories.First().Category.Name)
            .Select(g => new RevenueByCategory
            {
                CategoryName = g.Key,
                Revenue = g.Sum(oi => oi.Quantity * oi.UnitPrice)
            })
            .ToListAsync();
    }
}