using EComCore.Domain.Entities;
using EComCore.Domain.Shared.RequestFeatures;

namespace EComCore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<int> GetTotalCountAsync();
    Task<int> GetLowStockProductsCountAsync();
    Task<IEnumerable<Product>> GetTopSellingProductsAsync(int count);
}