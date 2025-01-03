using EComCore.Domain.DTOs.CartDTO;

namespace EComCore.Domain.Services.Commands;

public interface ICartCommandService
{
    Task<int> AddToCartAsync(AddToCartDto dto);
    Task UpdateCartItemAsync(UpdateCartItemDto dto);
    Task RemoveFromCartAsync(int userId, int productId);
}