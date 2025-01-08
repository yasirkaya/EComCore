using EComCore.Domain.DTOs.AuthDTO;

namespace EComCore.Domain.Services.Auth;

public interface IAuthCommandService
{
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task LogoutAsync(string email);
    Task ForgotPasswordAsync(string email);
    Task ResetPasswordAsync(string email, string token, string newPassword);
    Task VerifyEmailAsync(string email, string token);
}