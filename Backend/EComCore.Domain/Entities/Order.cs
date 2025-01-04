using System;
using System.Collections.Generic;

namespace EComCore.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int PaymentId { get; set; }
        public int ShipmentId { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
        public Payment Payment { get; set; }
        public Shipment Shipment { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


    }
}