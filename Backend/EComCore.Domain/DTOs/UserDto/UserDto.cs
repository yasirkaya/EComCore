namespace EComCore.Domain.DTOs.UserDTO;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public bool IsEmailVerified { get; set; }
}