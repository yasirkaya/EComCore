using EComCore.Domain.Enums;

namespace EComCore.Domain.DTOs.OrderDTO
{
    public class UpdateOrderStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}