using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IAttributeValueRepository : IRepository<AttributeValue>
{
    Task<IEnumerable<AttributeValue>> GetValuesByAttributeIdAsync(int attributeId);
    Task RemoveRangeAsync(IEnumerable<AttributeValue> attributeValues);
}