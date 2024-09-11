using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Queries;

public class GetCategoriesByProductIdQueryHandler : IRequestHandler<GetCategoriesByProductIdQuery, IEnumerable<ProductToCategoryDto>>
{
    private readonly IProductToCategoryQueryService _productToCategoryQueryService;
    public GetCategoriesByProductIdQueryHandler(IProductToCategoryQueryService productToCategoryQueryService)
    {
        _productToCategoryQueryService = productToCategoryQueryService;
    }

    public async Task<IEnumerable<ProductToCategoryDto>> Handle(GetCategoriesByProductIdQuery request, CancellationToken cancellationToken)
    {
        return await _productToCategoryQueryService.GetCategoriesByProductIdAsync(request.ProductId);
    }
}