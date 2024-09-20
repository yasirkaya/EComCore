using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role> GetByNameAsync(string name);
}