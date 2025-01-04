using System.Threading.Tasks;
using EComCore.Domain.DTOs.OrderDTO;

namespace EComCore.Domain.Services.Commands
{
    public interface IOrderCommandService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<OrderDto> UpdateOrderStatusAsync(UpdateOrderStatusDto updateOrderStatusDto);
        Task<bool> CancelOrderAsync(int orderId);
    }
}