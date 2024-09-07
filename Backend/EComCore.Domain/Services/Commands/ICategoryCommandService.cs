using EComCore.Domain.DTOs.CategoryDTO;

namespace EComCore.Domain.Services.Commands;

public interface ICategoryCommandService
{
    Task<int> AddAsync(CreateCategoryDto dto);
    Task UpdateAsync(UpdateCategoryDto dto);
    Task DeleteAsync(DeleteCategoryDto dto);
}