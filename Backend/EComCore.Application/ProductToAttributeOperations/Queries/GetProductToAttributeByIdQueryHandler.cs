using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands.Queries;

public class GetProductToAttributeByIdQueryHandler : IRequestHandler<GetProductToAttributeByIdQuery, ProductToAttributeDto>
{
    private readonly IProductToAttributeQueryService _productToAttributeQueryService;
    public GetProductToAttributeByIdQueryHandler(IProductToAttributeQueryService productToAttributeQueryService)
    {
        _productToAttributeQueryService = productToAttributeQueryService;
    }

    public async Task<ProductToAttributeDto> Handle(GetProductToAttributeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productToAttributeQueryService.GetByIdAsync(request.Id);
    }
}