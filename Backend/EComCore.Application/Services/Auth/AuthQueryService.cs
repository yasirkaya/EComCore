using AutoMapper;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Auth;

namespace EComCore.Application.Services.Auth;

public class AuthQueryService : IAuthQueryService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthQueryService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> GetCurrentUserAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");

        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> ValidateTokenAsync(string token)
    {
        var user = await _userRepository.GetByRefreshTokenAsync(token);
        return user != null;
    }

    public async Task<bool> ValidateResetTokenAsync(string email, string token)
    {
        var user = await _userRepository.GetByPasswordResetTokenAsync(token);
        return user != null && user.Email == email && user.PasswordResetTokenExpiry > DateTime.UtcNow;
    }
}