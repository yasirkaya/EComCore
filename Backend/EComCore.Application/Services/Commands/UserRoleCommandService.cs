using AutoMapper;
using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class UserRoleCommandService : IUserRoleCommandService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;
    public UserRoleCommandService(IUserRoleRepository userRoleRepository, IMapper mapper)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(CreateUserRoleDto dto)
    {
        var IsExist = await _userRoleRepository.IsExistAsync(dto.UserId, dto.RoleId);

        if (IsExist)
        {
            throw new Exception("This role is already assigned to the user.");
        }

        var userRole = _mapper.Map<UserRole>(dto);
        await _userRoleRepository.AddAsync(userRole);
        return userRole.Id;
    }

    public async Task DeleteAsync(DeleteUserRoleDto dto)
    {
        var userRole = await _userRoleRepository.GetByIdAsync(dto.Id);
        await userRole.EnsureNotNullAsync(id: dto.Id);

        await _userRoleRepository.DeleteAsync(userRole);
    }
}