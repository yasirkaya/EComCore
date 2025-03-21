using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId);
    Task<IEnumerable<OrderItem>> GetByProductVariantIdAsync(int productVariantId);
    Task<IEnumerable<OrderItem>> GetByOrderIdWithDetailsAsync(int orderId);
    Task<IEnumerable<RevenueByCategory>> GetRevenueByCategoryAsync();
}

public class RevenueByCategory
{
    public string CategoryName { get; set; }
    public decimal Revenue { get; set; }
}