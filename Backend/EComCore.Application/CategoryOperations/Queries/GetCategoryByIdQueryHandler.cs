using EComCore.Domain.DTOs.CategoryDto;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ICategoryQueryService _categoryQueryService;
    public GetCategoryByIdQueryHandler(ICategoryQueryService categoryQueryService)
    {
        _categoryQueryService = categoryQueryService;
    }

    public Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = _categoryQueryService.GetByIdAsync(request.Id);
        return category;
    }
}