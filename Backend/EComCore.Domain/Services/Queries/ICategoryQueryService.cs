using EComCore.Domain.DTOs.CategoryDTO;

namespace EComCore.Domain.Services.Queries;

public interface ICategoryQueryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);
    Task<IEnumerable<CategoryDto>> GetSubcategoriesAsync(int parentId);
}