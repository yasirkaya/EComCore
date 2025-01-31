using System.Collections.Generic;
using System.Threading.Tasks;
using EComCore.Domain.DTOs.OrderDTO;
using EComCore.Domain.Enums;

namespace EComCore.Domain.Services.Queries
{
    public interface IOrderQueryService
    {
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<List<OrderDto>> GetUserOrdersAsync(int userId);
        Task<List<OrderDto>> GetOrdersByStatusAsync(OrderStatus status);
        Task<List<OrderDto>> GetAllOrdersAsync();
    }
}