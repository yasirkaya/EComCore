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
   public bool IsEmailVerified { get; set; }
   public string? EmailVerificationToken { get; set; }
   public string? PasswordResetToken { get; set; }
   public DateTime? PasswordResetTokenExpiry { get; set; }
   public bool IsActive { get; set; } = true;
}