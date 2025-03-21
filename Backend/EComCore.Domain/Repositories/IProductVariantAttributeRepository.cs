using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories
{
    public interface IProductVariantAttributeRepository : IRepository<ProductVariantAttribute>
    {
        Task<IEnumerable<ProductVariantAttribute>> GetByProductVariantIdAsync(int productVariantId);
        Task<IEnumerable<ProductVariantAttribute>> GetByAttributeIdAsync(int attributeId);
        Task<IEnumerable<ProductVariantAttribute>> GetByAttributeValueIdAsync(int attributeValueId);
    }
}