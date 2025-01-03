using System.Threading.Tasks;
using EComCore.Domain.DTOs.CartDTO;

namespace EComCore.Domain.Services.Queries;

public interface ICartQueryService
{
    Task<CartDto> GetByUserIdAsync(int userId);
}