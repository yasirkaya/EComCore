using EComCore.Domain.DTOs.ProductToCategoryDTO;

namespace EComCore.Domain.Services.Commands;

public interface IProductToCategoryCommandService
{
    Task<int> AddAsync(CreateProductToCategoryDto dto);
    Task UpdateAsync(UpdateProductToCategoryDto dto);
    Task DeleteAsync(DeleteProductToCategoryDto dto);
    Task DeleteProductFromCategoriesAsync(int productId);
}