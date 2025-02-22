using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.Services.Queries
{
    public class PermissionQueryService : IPermissionQueryService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionQueryService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _permissionRepository.GetAllAsync();
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            await permission.EnsureNotNullAsync(id: id);

            return permission;
        }
    }
}