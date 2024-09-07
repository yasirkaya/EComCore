using AutoMapper;
using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductOperations.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductCommandService _productCommandService;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IProductCommandService productCommandService, IMapper mapper)
    {
        _productCommandService = productCommandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<CreateProductDto>(request);
        return await _productCommandService.AddAsync(product);
    }
}