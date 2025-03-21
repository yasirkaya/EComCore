using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<int> GetTotalCountAsync();
    Task<int> GetLowStockProductsCountAsync();
    Task<IEnumerable<Product>> GetTopSellingProductsAsync(int count);
}