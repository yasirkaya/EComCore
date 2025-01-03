using System;

namespace EComCore.Domain.Entities;

public class CartItem : BaseEntity
{
    public int CartId { get; set; }
    public Cart Cart { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}