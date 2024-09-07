using AutoMapper;
using EComCore.Domain.Repositories;
using EComCore.Domain.Entities;
using MediatR;
using EComCore.Domain.DTOs.CategoryDTO;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.CategoryOperations.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryCommandService _categoryCommandService;
    private readonly IMapper _mapper;
    public CreateCategoryCommandHandler(ICategoryCommandService categoryCommandService, IMapper mapper)
    {
        _categoryCommandService = categoryCommandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<CreateCategoryDto>(request);
        var categoryId = await _categoryCommandService.AddAsync(category);
        return categoryId;
    }
}