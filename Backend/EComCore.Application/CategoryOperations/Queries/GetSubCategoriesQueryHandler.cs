using EComCore.Domain.DTOs.CategoryDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetSubCategoriesQueryHandler : IRequestHandler<GetSubCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryQueryService _categoryQueryService;
    public GetSubCategoriesQueryHandler(ICategoryQueryService categoryQueryService)
    {
        _categoryQueryService = categoryQueryService;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryQueryService.GetSubcategoriesAsync(request.Id);
        return categories;
    }
}