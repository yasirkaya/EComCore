using System.Net;
using System.Net.Mail;
using EComCore.Domain.Configurations;
using EComCore.Domain.Services.Shared;
using Microsoft.Extensions.Options;

namespace EComCore.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly EmailConfiguration _emailConfig;

    public EmailService(IOptions<EmailConfiguration> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public async Task SendPasswordResetEmailAsync(string email, string resetToken)
    {
        var subject = "Şifre Sıfırlama İsteği";
        var resetLink = $"https://yourwebsite.com/reset-password?token={resetToken}&email={WebUtility.UrlEncode(email)}";
        var body = $@"
            <h2>Şifre Sıfırlama İsteği</h2>
            <p>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın:</p>
            <p><a href='{resetLink}'>Şifremi Sıfırla</a></p>
            <p>Bu bağlantı 24 saat süreyle geçerlidir.</p>
            <p>Eğer bu isteği siz yapmadıysanız, bu e-postayı görmezden gelebilirsiniz.</p>";

        await SendEmailAsync(email, subject, body);
    }

    public async Task SendEmailVerificationAsync(string email, string verificationToken)
    {
        var subject = "E-posta Doğrulama";
        var verificationLink = $"https://yourwebsite.com/verify-email?token={verificationToken}&email={WebUtility.UrlEncode(email)}";
        var body = $@"
            <h2>E-posta Doğrulama</h2>
            <p>E-posta adresinizi doğrulamak için aşağıdaki bağlantıya tıklayın:</p>
            <p><a href='{verificationLink}'>E-postamı Doğrula</a></p>
            <p>Eğer bu hesabı siz oluşturmadıysanız, bu e-postayı görmezden gelebilirsiniz.</p>";

        await SendEmailAsync(email, subject, body);
    }

    private async Task SendEmailAsync(string to, string subject, string body)
    {
        using var client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort)
        {
            Credentials = new NetworkCredential(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailConfig.FromEmail, _emailConfig.FromName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(to);

        await client.SendMailAsync(mailMessage);
    }

    public Task SendWelcomeEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
}