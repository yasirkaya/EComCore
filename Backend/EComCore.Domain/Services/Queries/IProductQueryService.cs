using EComCore.Domain.DTOs.ProductDTO;

namespace EComCore.Domain.Services.Queries;

public interface IProductQueryService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(int id);
}