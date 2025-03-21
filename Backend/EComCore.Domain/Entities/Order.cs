using System;
using System.Collections.Generic;
using EComCore.Domain.Enums;

namespace EComCore.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public int ShipmentId { get; set; }
        public int? PaymentId { get; set; }
        public int AddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsDeleted { get; set; }
        public User User { get; set; }
        public Shipment Shipment { get; set; }
        public Payment Payment { get; set; }
        public Address Address { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}