using System.Collections.Generic;

namespace EComCore.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}