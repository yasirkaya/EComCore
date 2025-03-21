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
            .Include(oi => oi.ProductVariant)
            .Where(oi => oi.OrderId == orderId)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetByProductVariantIdAsync(int productVariantId)
    {
        return await _context.OrderItems
            .Include(oi => oi.Order)
            .Where(oi => oi.ProductVariantId == productVariantId)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetByOrderIdWithDetailsAsync(int orderId)
    {
        return await _context.OrderItems
            .Include(oi => oi.ProductVariant)
            .Include(oi => oi.Order)
            .Where(oi => oi.OrderId == orderId)
            .OrderBy(oi => oi.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<RevenueByCategory>> GetRevenueByCategoryAsync()
    {
        return await _context.OrderItems
            .Include(oi => oi.ProductVariant)
                .ThenInclude(pv => pv.Product)
                    .ThenInclude(p => p.ProductToCategories)
                        .ThenInclude(ptc => ptc.Category)
            .Include(oi => oi.Order)
            .Where(oi => oi.Order.OrderStatus == OrderStatus.Completed)
            .GroupBy(oi => oi.ProductVariant.Product.ProductToCategories.First().Category.Name)
            .Select(g => new RevenueByCategory
            {
                CategoryName = g.Key,
                Revenue = g.Sum(oi => oi.Quantity * oi.UnitPrice)
            })
            .ToListAsync();
    }
}