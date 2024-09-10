using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class CreateProductToAttributeCommandHandler : IRequestHandler<CreateProductToAttributeCommand, int>
{
    private readonly IProductToAttributeCommandService _productToAttributeCommandService;
    private readonly IMapper _mapper;
    public CreateProductToAttributeCommandHandler(IProductToAttributeCommandService productToAttributeCommandService, IMapper mapper)
    {
        _productToAttributeCommandService = productToAttributeCommandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProductToAttributeCommand request, CancellationToken cancellationToken)
    {
        var prodAttr = _mapper.Map<CreateProductToAttributeDto>(request);
        return await _productToAttributeCommandService.AddAsync(prodAttr);

    }
}
