using AutoMapper;
using EComCore.Domain.DTOs.CategoryDto;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.CategoryOperations.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryCommandService _categoryCommandService;
    private readonly IMapper _mapper;
    public DeleteCategoryCommandHandler(ICategoryCommandService categoryCommandService, IMapper mapper)
    {
        _categoryCommandService = categoryCommandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryCommandService.DeleteAsync(_mapper.Map<DeleteCategoryDto>(request));
        return;
    }
}