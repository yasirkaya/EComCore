using System.ComponentModel.DataAnnotations;

namespace EComCore.Domain.Entities;

public class User : BaseEntity
{
   [Required]
   public string Username { get; set; }
   [Required]
   public string Email { get; set; }
   [Required]
   public string PasswordHash { get; set; }
   public string? RefreshToken { get; set; }
   public DateTime? RefreshTokenExpiryTime { get; set; }
   public bool IsEmailVerified { get; set; }
   public string? EmailVerificationToken { get; set; }
   public string? PasswordResetToken { get; set; }
   public DateTime? PasswordResetTokenExpiry { get; set; }
   public bool IsActive { get; set; } = true;
   public List<Order> Orders { get; set; }
   public List<Review> Reviews { get; set; }
   public Cart Cart { get; set; }
   public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
   public List<Address> Addresses { get; set; }
}