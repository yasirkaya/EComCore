using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Queries;

public interface IRoleQueryService
{
    Task<Role> GetByNameAsync(string name);
    Task<Role> GetByIdAsync(int id);
}