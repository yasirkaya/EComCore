using EComCore.Domain.DTOs.UserDTO;

namespace EComCore.Domain.DTOs.AuthDTO;

public class AuthResponseDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public UserDto User { get; set; }
}