using System.Security.Cryptography;
using System.Text;

namespace EComCore.Domain.Extensions;

public static class PasswordHashExtensions
{
    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        var hashedPassword = HashPassword(enteredPassword);
        return hashedPassword == storedHash;
    }
}