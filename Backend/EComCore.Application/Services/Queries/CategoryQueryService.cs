using AutoMapper;
using EComCore.Domain.DTOs.CategoryDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;
using Microsoft.IdentityModel.Tokens;

namespace EComCore.Application.CategoryOperations.Queries;

public class CategoryQueryService : ICategoryQueryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryQueryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        await category.EnsureNotNullAsync(id: id);

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetSubcategoriesAsync(int parentId)
    {
        var categories = await _categoryRepository.GetSubcategoriesAsync(parentId);
        await categories.EnsureNotNullOrEmptyAsync(message: "No subcategories found for this category");

        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
}