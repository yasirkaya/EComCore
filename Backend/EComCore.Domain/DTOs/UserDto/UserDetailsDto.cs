namespace EComCore.Domain.DTOs.UserDTO;

public class UserDetailsDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string RefreshToken { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}