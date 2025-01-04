using System.Collections.Generic;
using System.Threading.Tasks;
using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetByUserIdAsync(int userId);
        Task<List<Order>> GetByStatusAsync(string status);
    }
}