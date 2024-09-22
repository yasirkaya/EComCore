namespace EComCore.Domain.Entities;

public class User
{
   public int Id { get; set; }
   public string Username { get; set; }
   public string PasswordHash { get; set; }
   public string Email { get; set; }
   public string? RefreshToken { get; set; }
   public DateTime? RefreshTokenExpiryTime { get; set; }
   public DateTime CreatedAt { get; set; }
   public DateTime UpdatedAt { get; set; }
   public bool IsActive { get; set; }

   public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
}