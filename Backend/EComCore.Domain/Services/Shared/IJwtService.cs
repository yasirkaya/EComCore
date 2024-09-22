using EComCore.Domain.DTOs.UserDTO;

namespace EComCore.Domain.Services.Shared;

public interface IJwtService
{
    Task<AuthTokenDto> GenerateTokenAsync(LoginDto dto);
}