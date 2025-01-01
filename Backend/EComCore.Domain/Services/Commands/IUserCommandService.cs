using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Commands;

public interface IUserCommandService
{
    Task<int> RegisterAsync(CreateUserDto createUserDto);
    Task<AuthenticatedUserDto> LoginAsync(LoginDto loginDto);
    Task DeleteUserAsync(DeleteUserDto dto);
    Task LogoutAsync(string email);
    Task VerifyEmailAsync(string email, string token);
    Task ForgotPasswordAsync(string email);
    Task ResetPasswordAsync(string email, string token, string newPassword);
}