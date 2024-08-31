using AutoMapper;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using MediatR;

namespace EComCore.Application.Services.CategoryOperations.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category == null)
        {
            throw new Exception($"Category with Id {request.Id} not found.");
        }

        _mapper.Map(request, category);

        await _categoryRepository.UpdateAsync(category);

        return;
    }
}