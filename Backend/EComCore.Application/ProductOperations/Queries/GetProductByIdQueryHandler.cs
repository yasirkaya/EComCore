using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.ProductOperations.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductQueryService _productQueryService;
    public GetProductByIdQueryHandler(IProductQueryService productQueryService)
    {
        _productQueryService = productQueryService;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productQueryService.GetByIdAsync(request.Id);
    }
}