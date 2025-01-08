namespace EComCore.Domain.Services.Shared;

public interface IEmailService
{
    Task SendPasswordResetEmailAsync(string email, string token);
    Task SendEmailVerificationAsync(string email, string token);
    Task SendWelcomeEmailAsync(string email);
}