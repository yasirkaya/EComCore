using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
}