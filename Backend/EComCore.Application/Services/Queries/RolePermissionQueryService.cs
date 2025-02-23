using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.Services.Queries
{
    public class RolePermissionQueryService : IRolePermissionQueryService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionQueryService(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<IEnumerable<RolePermission>> GetAllAsync()
        {
            return await _rolePermissionRepository.GetAllAsync();
        }

        public async Task<RolePermission> GetByIdAsync(int id)
        {
            return await _rolePermissionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId)
        {
            return await _rolePermissionRepository.GetByRoleIdAsync(roleId);
        }

        public async Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId)
        {
            return await _rolePermissionRepository.GetByPermissionIdAsync(permissionId);
        }

        public Task<bool> IsExistAsync(int roleId, int permissionId)
        {
            return _rolePermissionRepository.IsExistAsync(roleId, permissionId);
        }
    }
}