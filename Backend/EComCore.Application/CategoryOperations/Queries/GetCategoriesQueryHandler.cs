using EComCore.Domain.DTOs.CategoryDto;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryQueryService _categoryQueryService;
    public GetCategoriesQueryHandler(ICategoryQueryService categoryQueryService)
    {
        _categoryQueryService = categoryQueryService;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _categoryQueryService.GetAllAsync();
        return result;
    }
}