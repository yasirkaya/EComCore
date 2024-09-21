using AutoMapper;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserQueryService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDetailsDto>> GetAllActiveUsersAsync()
    {
        var users = await _userRepository.GetAllActiveUsersAsync();
        await users.EnsureNotNullOrEmptyAsync();

        return _mapper.Map<IEnumerable<UserDetailsDto>>(users);
    }

    public async Task<UserDetailsDto> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        await user.EnsureNotNullAsync(message: $"User with Email {email} not found");

        return _mapper.Map<UserDetailsDto>(user);
    }

    public async Task<UserDetailsDto> GetByIdActiveAsync(int id)
    {
        var user = await _userRepository.GetByIdActiveAsync(id);
        await user.EnsureNotNullAsync(id: id);

        return _mapper.Map<UserDetailsDto>(user);
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return user != null;
    }
}