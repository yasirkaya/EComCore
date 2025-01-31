using System;
using System.Collections.Generic;
using EComCore.Domain.Enums;

namespace EComCore.Domain.DTOs.OrderDTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int PaymentId { get; set; }
        public int ShipmentId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}