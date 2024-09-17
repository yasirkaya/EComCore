namespace EComCore.Domain.DTOs.UserDTO;

public class UpdateUserDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? Email { get; set; }
}