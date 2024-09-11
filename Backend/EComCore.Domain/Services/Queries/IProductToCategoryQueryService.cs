using EComCore.Domain.DTOs.ProductToCategoryDTO;

namespace EComCore.Domain.Services.Queries;

public interface IProductToCategoryQueryService
{
    Task<IEnumerable<ProductToCategoryDto>> GetProductsByCategoryIdAsync(int categoryId);
    Task<IEnumerable<ProductToCategoryDto>> GetCategoriesByProductIdAsync(int productId);
    Task<IEnumerable<ProductToCategoryDto>> GetAllAsync();
}