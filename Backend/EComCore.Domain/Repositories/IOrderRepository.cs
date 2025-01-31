using System.Collections.Generic;
using System.Threading.Tasks;
using EComCore.Domain.Entities;
using EComCore.Domain.Enums;

namespace EComCore.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetByUserIdAsync(int userId);
        Task<List<Order>> GetByStatusAsync(OrderStatus status);
    }
}