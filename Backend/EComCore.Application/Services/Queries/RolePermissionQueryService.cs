using AutoMapper;
using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.Services.Queries
{
    public class RolePermissionQueryService : IRolePermissionQueryService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IMapper _mapper;

        public RolePermissionQueryService(IRolePermissionRepository rolePermissionRepository, IMapper mapper)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolePermissionDto>> GetAllAsync()
        {
            var rolePermissions = await _rolePermissionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<RolePermissionDto>>(rolePermissions);
        }

        public async Task<RolePermissionDto> GetByIdAsync(int id)
        {
            var rolePermission = await _rolePermissionRepository.GetByIdAsync(id);
            await rolePermission.EnsureNotNullAsync(id: id);

            return _mapper.Map<RolePermissionDto>(rolePermission);
        }

        public async Task<IEnumerable<RolePermissionDto>> GetByRoleIdAsync(int roleId)
        {
            var rolePermissions = await _rolePermissionRepository.GetByRoleIdAsync(roleId);
            await rolePermissions.EnsureNotNullAsync(id: roleId);

            return _mapper.Map<IEnumerable<RolePermissionDto>>(rolePermissions);
        }

        public async Task<IEnumerable<RolePermissionDto>> GetByPermissionIdAsync(int permissionId)
        {
            var rolePermissions = await _rolePermissionRepository.GetByPermissionIdAsync(permissionId);
            await rolePermissions.EnsureNotNullAsync(id: permissionId);

            return _mapper.Map<IEnumerable<RolePermissionDto>>(rolePermissions);
        }

        public Task<bool> IsExistAsync(int roleId, int permissionId)
        {
            return _rolePermissionRepository.IsExistAsync(roleId, permissionId);
        }
    }
}