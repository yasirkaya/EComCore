using AutoMapper;
using EComCore.Domain.Repositories;
using EComCore.Domain.Entities;
using MediatR;

namespace EComCore.Application.Services.CategoryOperations.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        await _categoryRepository.AddAsync(category);
        return category.Id;
    }
}