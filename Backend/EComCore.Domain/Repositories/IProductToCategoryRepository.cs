using EComCore.Domain.Entities;
using EComCore.Domain.Shared.RequestFeatures;

namespace EComCore.Domain.Repositories;

public interface IProductToCategoryRepository : IRepository<ProductToCategory>
{
    Task<IEnumerable<ProductToCategory>> GetByProductIdAsync(int productId);
    Task<IEnumerable<ProductToCategory>> GetByCategoryIdAsync(int categoryId, ProductToCategoryParameters productToCategoryParameters);
    Task DeleteByProductIdAsync(IEnumerable<ProductToCategory> prodCats);
}