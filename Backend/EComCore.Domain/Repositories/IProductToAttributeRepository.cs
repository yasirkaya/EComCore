using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IProductToAttributeRepository : IRepository<ProductToAttribute>
{
    Task DeleteRangeAsync(IEnumerable<ProductToAttribute> productToAttributes);
    Task AddRangeAsync(IEnumerable<ProductToAttribute> productToAttributes);
    Task<ProductToAttribute> FindByProductIdAndAttributeIdAsync(int productId, int attributeId);
    Task<IEnumerable<ProductToAttribute>> GetAttributesByProductIdAsync(int productId);
}