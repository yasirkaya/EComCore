using EComCore.Domain.DTOs.UserDTO;

namespace EComCore.Domain.Services.Shared;

public interface IJwtService
{
    string GenerateToken(LoginDto dto);
}