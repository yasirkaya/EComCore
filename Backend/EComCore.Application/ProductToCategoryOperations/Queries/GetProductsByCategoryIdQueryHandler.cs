using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Queries;

public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, IEnumerable<ProductToCategoryDto>>
{
    private readonly IProductToCategoryQueryService _productToCategoryQueryService;
    public GetProductsByCategoryIdQueryHandler(IProductToCategoryQueryService productToCategoryQueryService)
    {
        _productToCategoryQueryService = productToCategoryQueryService;
    }

    public async Task<IEnumerable<ProductToCategoryDto>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        return await _productToCategoryQueryService.GetProductsByCategoryIdAsync(request.CategoryId, request.ProductToCategoryParameters);
    }
}