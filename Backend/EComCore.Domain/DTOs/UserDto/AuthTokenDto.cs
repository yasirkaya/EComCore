namespace EComCore.Domain.DTOs.UserDTO;

public class AuthTokenDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}