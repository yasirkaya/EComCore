using System.Collections.Generic;

namespace EComCore.Domain.DTOs.OrderDTO
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int PaymentId { get; set; }
        public int ShipmentId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}