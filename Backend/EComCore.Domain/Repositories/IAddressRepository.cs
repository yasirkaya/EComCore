using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IAddressRepository : IRepository<Address>
{
    Task<IEnumerable<Address>> GetByUserIdAsync(int userId);
}