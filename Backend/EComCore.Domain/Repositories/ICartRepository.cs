using System.Threading.Tasks;
using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart> GetByUserIdAsync(int userId);
    }
}