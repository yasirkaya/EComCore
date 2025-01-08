using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByRefreshTokenAsync(string refreshToken);
    Task<User> GetByPasswordResetTokenAsync(string resetToken);
    Task<User> GetByEmailVerificationTokenAsync(string verificationToken);
    Task<IEnumerable<User>> GetAllActiveUsersAsync();
}