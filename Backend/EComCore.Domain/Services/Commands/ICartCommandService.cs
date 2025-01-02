using System.Threading.Tasks;

namespace EComCore.Domain.Services.Commands
{
    public interface ICartCommandService
    {
        Task<bool> AddToCartAsync(int userId, int productId, int quantity);
        Task<bool> UpdateCartItemAsync(int userId, int productId, int quantity);
        Task<bool> RemoveFromCartAsync(int userId, int productId);
    }
}