using AutoMapper;
using EComCore.Domain.DTOs.CategoryDto;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.CategoryOperations.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryCommandService _categoryCommandService;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryCommandService categoryCommandService, IMapper mapper)
    {
        _categoryCommandService = categoryCommandService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryCommandService.UpdateAsync(_mapper.Map<UpdateCategoryDto>(request));

        return;
    }
}