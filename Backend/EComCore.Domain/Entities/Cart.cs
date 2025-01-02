using System;
using System.Collections.Generic;

namespace EComCore.Domain.Entities;

public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }

    public Cart()
    {
        CartItems = new List<CartItem>();
    }
}