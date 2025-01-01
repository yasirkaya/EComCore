namespace EComCore.Domain.Services.Shared;

public interface IEmailService
{
    Task SendPasswordResetEmailAsync(string email, string resetToken);
    Task SendEmailVerificationAsync(string email, string verificationToken);
}