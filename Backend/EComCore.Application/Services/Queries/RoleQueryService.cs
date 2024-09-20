using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class RoleQueryService : IRoleQueryService
{
    IRoleRepository _roleRepository;
    public RoleQueryService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        await role.EnsureNotNullAsync(id: id);

        return role;
    }

    public async Task<Role> GetByNameAsync(string name)
    {
        var role = await _roleRepository.GetByNameAsync(name);
        await role.EnsureNotNullAsync(message: $"Role with Name {name} not found");

        return role;
    }
}