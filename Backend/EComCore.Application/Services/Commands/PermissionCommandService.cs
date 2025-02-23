using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands
{
    public class PermissionCommandService : IPermissionCommandService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionCommandService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task CreateAsync(Permission permission)
        {
            await _permissionRepository.AddAsync(permission);
        }

        public async Task UpdateAsync(Permission permission)
        {
            var per = await _permissionRepository.GetByIdAsync(permission.Id);
            await per.EnsureNotNullAsync(id: per.Id);
            per.Name = permission.Name;
            await _permissionRepository.UpdateAsync(per);
        }

        public async Task DeleteAsync(int id)
        {
            var per = await _permissionRepository.GetByIdAsync(id);
            await per.EnsureNotNullAsync(id: per.Id);

            await _permissionRepository.DeleteAsync(per);
        }
    }
}