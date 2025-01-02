using System.Collections.Generic;
using System.Threading.Tasks;
using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart> GetActiveCartByUserIdAsync(int userId);
        Task<bool> AddItemToCartAsync(int cartId, CartItem item);
        Task<bool> RemoveItemFromCartAsync(int cartId, int productId);
        Task<bool> UpdateItemQuantityAsync(int cartId, int productId, int quantity);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId);
    }
}