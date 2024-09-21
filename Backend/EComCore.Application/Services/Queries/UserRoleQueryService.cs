using AutoMapper;
using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class UserRoleQueryService : IUserRoleQueryService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    public UserRoleQueryService(IUserRoleRepository userRoleRepository, IMapper mapper, IRoleRepository roleRepository)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<UserRoleDetailsDto>> GetUserRolesAsync(int userId)
    {
        var userRoles = await _userRoleRepository.GetByUserIdAsync(userId);
        await userRoles.EnsureNotNullOrEmptyAsync(id: userId);
        return _mapper.Map<IEnumerable<UserRoleDetailsDto>>(userRoles);
    }

    public async Task<IEnumerable<UserDetailsDto>> GetUsersInRoleAsync(string roleName)
    {
        var users = await _userRoleRepository.GetByRoleNameAsync(roleName);
        await users.EnsureNotNullOrEmptyAsync(message: $"Role with Name {roleName} not found or is empty");

        return _mapper.Map<IEnumerable<UserDetailsDto>>(users);
    }

    public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
    {
        var role = await _roleRepository.GetByNameAsync(roleName);
        await role.EnsureNotNullAsync(message: $"Role with Name {roleName} not found");

        return await _userRoleRepository.IsExistAsync(userId, role.Id);
    }
}