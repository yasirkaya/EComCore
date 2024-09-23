using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllActiveUsersAsync();
    Task<User> GetByIdActiveAsync(int id);
    Task<User> GetByRefreshTokenAsync(string refreshToken);
}