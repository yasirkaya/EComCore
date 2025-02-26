using AutoMapper;
using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class RoleQueryService : IRoleQueryService
{
    IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    public RoleQueryService(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RoleDto>> GetAllAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        await roles.EnsureNotNullOrEmptyAsync();

        return _mapper.Map<IEnumerable<RoleDto>>(roles);
    }

    public async Task<RoleDto> GetByIdAsync(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        await role.EnsureNotNullAsync(id: id);

        return _mapper.Map<RoleDto>(role);
    }

    public async Task<RoleDto> GetByNameAsync(string name)
    {
        var role = await _roleRepository.GetByNameAsync(name);
        await role.EnsureNotNullAsync(message: $"Role with Name {name} not found");

        return _mapper.Map<RoleDto>(role);
    }
}