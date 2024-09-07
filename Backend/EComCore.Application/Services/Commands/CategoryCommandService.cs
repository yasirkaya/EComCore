using AutoMapper;
using EComCore.Domain.DTOs.CategoryDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class CategoryCommandService : ICategoryCommandService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryCommandService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(CreateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        await _categoryRepository.AddAsync(category);
        return category.Id;
    }

    public async Task DeleteAsync(DeleteCategoryDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.Id);

        if (category == null)
        {
            throw new Exception($"Category with Id {dto.Id} not found.");
        }

        await _categoryRepository.DeleteAsync(category);
    }

    public async Task UpdateAsync(UpdateCategoryDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.Id);

        if (category == null)
        {
            throw new Exception($"Category with Id {dto.Id} not found.");
        }

        _mapper.Map(dto, category);
        await _categoryRepository.UpdateAsync(category);
    }
}