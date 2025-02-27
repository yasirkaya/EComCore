using AutoMapper;
using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;
using EComCore.ınfrastructure.Repositories;

namespace EComCore.Application.Services.Commands;

public class RoleCommandService : IRoleCommandService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IRolePermissionRepository _rolePermissionRepository;
    private readonly IMapper _mapper;
    public RoleCommandService(IRoleRepository roleRepository, IMapper mapper, IRolePermissionRepository rolePermissionRepository)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
        _rolePermissionRepository = rolePermissionRepository;
    }

    public async Task CreateAsync(CreateRoleDto roleDto)
    {
        await _roleRepository.RunInTransactionAsync(async () =>
        {
            var role = _mapper.Map<Role>(roleDto);
            await _roleRepository.AddAsync(role);

            var roleId = role.Id;

            if (roleDto.PermissionIds != null && roleDto.PermissionIds.Any())
            {
                var rolePermissions = roleDto.PermissionIds
                    .Select(permissionId => new RolePermission
                    {
                        RoleId = roleId,
                        PermissionId = permissionId
                    }).ToList();

                await _rolePermissionRepository.AddRangeAsync(rolePermissions);
            }
        });
    }


    public async Task UpdateAsync(UpdateRoleDto roleDto)
    {
        await _roleRepository.RunInTransactionAsync(async () =>
        {
            var role = await _roleRepository.GetByIdAsync(roleDto.Id);
            await role.EnsureNotNullAsync(id: roleDto.Id);

            _mapper.Map(roleDto, role);
            await _roleRepository.UpdateAsync(role);

            var existingRolePermissions = await _rolePermissionRepository.GetByRoleIdAsync(roleDto.Id);
            await existingRolePermissions.EnsureNotNullAsync(message: "Role permissions not found", id: roleDto.Id);

            var existingPermissionIds = existingRolePermissions.Select(rp => rp.PermissionId).ToList();

            var newPermissions = roleDto.PermissionIds.Except(existingPermissionIds)
                .Select(permissinId => new RolePermission
                {
                    RoleId = roleDto.Id,
                    PermissionId = permissinId
                }).ToList();

            var permissinsToRemove = existingRolePermissions
                .Where(rp => !roleDto.PermissionIds.Contains(rp.PermissionId))
                .ToList();

            if (newPermissions.Any())
                await _rolePermissionRepository.AddRangeAsync(newPermissions);

            if (permissinsToRemove.Any())
                await _rolePermissionRepository.DeleteRangeAsync(permissinsToRemove);
        });




    }

    public async Task DeleteAsync(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        await role.EnsureNotNullAsync(id: id);
        await _roleRepository.DeleteAsync(role);
    }
}