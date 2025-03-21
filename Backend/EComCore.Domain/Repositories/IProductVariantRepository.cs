using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories
{
    public interface IProductVariantRepository : IRepository<ProductVariant>
    {
        Task<IEnumerable<ProductVariant>> GetByProductIdAsync(int productId);
        Task<ProductVariant> GetBySkuAsync(string sku);
        Task<IEnumerable<ProductVariant>> GetByAttributeValueAsync(int attributeValueId);
    }
}