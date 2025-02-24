using AutoMapper;
using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class RoleCommandService : IRoleCommandService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    public RoleCommandService(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<RoleDto> CreateAsync(RoleDto roleDto)
    {
        var role = _mapper.Map<Role>(roleDto);
        await _roleRepository.AddAsync(role);
        return _mapper.Map<RoleDto>(role);
    }

    public async Task<RoleDto> UpdateAsync(RoleDto roleDto)
    {
        var role = await _roleRepository.GetByIdAsync(roleDto.Id);
        await role.EnsureNotNullAsync(id: roleDto.Id);

        _mapper.Map(roleDto, role);
        await _roleRepository.UpdateAsync(role);

        return _mapper.Map<RoleDto>(role);
    }

    public async Task DeleteAsync(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        await role.EnsureNotNullAsync(id: id);
        await _roleRepository.DeleteAsync(role);
    }
}