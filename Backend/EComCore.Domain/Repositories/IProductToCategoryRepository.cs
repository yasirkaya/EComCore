using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IProductToCategoryRepository : IRepository<ProductToCategory>
{
    Task<IEnumerable<ProductToCategory>> GetByProductIdAsync(int productId);
    Task<IEnumerable<ProductToCategory>> GetByCategoryIdAsync(int categoryId);
    Task DeleteByProductIdAsync(IEnumerable<ProductToCategory> prodCats);
}