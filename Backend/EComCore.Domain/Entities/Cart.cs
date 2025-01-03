using System.Collections.Generic;

namespace EComCore.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}