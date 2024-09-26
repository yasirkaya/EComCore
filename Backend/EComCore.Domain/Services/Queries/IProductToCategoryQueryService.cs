using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Shared.RequestFeatures;

namespace EComCore.Domain.Services.Queries;

public interface IProductToCategoryQueryService
{
    Task<IEnumerable<ProductToCategoryDto>> GetProductsByCategoryIdAsync(int categoryId, ProductToCategoryParameters productToCategoryParameters);
    Task<IEnumerable<ProductToCategoryDto>> GetCategoriesByProductIdAsync(int productId);
    Task<IEnumerable<ProductToCategoryDto>> GetAllAsync();
}