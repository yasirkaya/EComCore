using EComCore.Domain.DTOs.ProductDTO;

namespace EComCore.Domain.Services.Queries;

public interface IProductQueryService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(int id);
    Task<bool> CheckProductStockAsync(int productId, int quantity);
    Task<bool> CheckProductPriceAsync(int productId, decimal requestedPrice);
}