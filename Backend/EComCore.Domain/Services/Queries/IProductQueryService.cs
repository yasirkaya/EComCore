using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Shared.RequestFeatures;

namespace EComCore.Domain.Services.Queries;

public interface IProductQueryService
{
    Task<IEnumerable<ProductDto>> GetAllAsync(ProductParameters productParameters);
    Task<ProductDto> GetByIdAsync(int id);
    Task<bool> CheckProductStockAsync(int productId, int quantity);
    Task<bool> CheckProductPriceAsync(int productId, decimal requestedPrice);
}