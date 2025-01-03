using System.Collections.Generic;

namespace EComCore.Domain.DTOs.CartDTO;

public class CartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ICollection<CartItemDto> Items { get; set; }
}

