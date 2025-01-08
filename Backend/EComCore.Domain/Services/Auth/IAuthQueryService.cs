using EComCore.Domain.DTOs.AuthDTO;
using EComCore.Domain.DTOs.UserDTO;

namespace EComCore.Domain.Services.Auth;

public interface IAuthQueryService
{
    Task<UserDto> GetCurrentUserAsync(string email);
    Task<bool> ValidateTokenAsync(string token);
    Task<bool> ValidateResetTokenAsync(string email, string token);
}