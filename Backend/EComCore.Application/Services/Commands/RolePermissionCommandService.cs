using AutoMapper;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands
{
    public class RolePermissionCommandService : IRolePermissionCommandService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IMapper _mapper;

        public RolePermissionCommandService(IRolePermissionRepository rolePermissionRepository, IMapper mapper)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(RolePermission rolePermission)
        {
            var entity = _mapper.Map<RolePermission>(rolePermission);
            await _rolePermissionRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var rolePermission = await _rolePermissionRepository.GetByIdAsync(id);
            await rolePermission.EnsureNotNullAsync(id: id);

            await _rolePermissionRepository.DeleteAsync(rolePermission);
        }

        public async Task UpdateAsync(RolePermission rolePermission)
        {
            var rolePer = await _rolePermissionRepository.GetByIdAsync(rolePermission.Id);
            await rolePer.EnsureNotNullAsync(id: rolePermission.Id);

            await _rolePermissionRepository.UpdateAsync(rolePer);
        }
    }
}