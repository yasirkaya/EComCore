namespace EComCore.Domain.DTOs.UserDTO;

public class AuthenticatedUserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}