using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId);
    Task<IEnumerable<OrderItem>> GetByProductIdAsync(int productId);
    Task<IEnumerable<RevenueByCategory>> GetRevenueByCategoryAsync();
}

public class RevenueByCategory
{
    public string CategoryName { get; set; }
    public decimal Revenue { get; set; }
}