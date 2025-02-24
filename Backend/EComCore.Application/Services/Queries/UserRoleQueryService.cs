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

    public async Task<IEnumerable<UserRoleDetailsDto>> GetAllAsync()
    {
        var userRoles = await _userRoleRepository.GetAllAsync();
        await userRoles.EnsureNotNullOrEmptyAsync();
        return _mapper.Map<IEnumerable<UserRoleDetailsDto>>(userRoles);
    }

    public async Task<UserRoleDetailsDto> GetByIdAsync(int id)
    {
        var userRole = _userRoleRepository.GetByIdAsync(id);
        await userRole.EnsureNotNullAsync(id: id);
        return _mapper.Map<UserRoleDetailsDto>(userRole);
    }

    public async Task<IEnumerable<UserRoleDetailsDto>> GetByUserIdAsync(int userId)
    {
        var userRoles = await _userRoleRepository.GetByUserIdAsync(userId);
        await userRoles.EnsureNotNullOrEmptyAsync(id: userId);
        return _mapper.Map<IEnumerable<UserRoleDetailsDto>>(userRoles);
    }

    public async Task<IEnumerable<UserRoleDetailsDto>> GetByRoleIdAsync(int roleId)
    {
        var users = await _userRoleRepository.GetByRoleIdAsync(roleId);
        await users.EnsureNotNullOrEmptyAsync(message: $"Role with ID {roleId} not found or is empty");

        return _mapper.Map<IEnumerable<UserRoleDetailsDto>>(users);
    }

    public async Task<bool> IsUserInRoleAsync(int userId, int roleId)
    {
        var role = await _roleRepository.GetByIdAsync(roleId);
        await role.EnsureNotNullAsync(message: $"Role with ID {roleId} not found");

        return await _userRoleRepository.IsExistAsync(userId, role.Id);
    }
}