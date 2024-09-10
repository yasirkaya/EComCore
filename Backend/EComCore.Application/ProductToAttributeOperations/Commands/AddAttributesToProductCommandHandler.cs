using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class AddAttributesToProductCommandHandler : IRequestHandler<AddAttributesToProductCommand>
{
    private readonly IProductToAttributeCommandService _productToAttributeCommandService;
    private readonly IMapper _mapper;
    public AddAttributesToProductCommandHandler(IProductToAttributeCommandService productToAttributeCommandService, IMapper mapper)
    {
        _productToAttributeCommandService = productToAttributeCommandService;
        _mapper = mapper;
    }

    public async Task Handle(AddAttributesToProductCommand request, CancellationToken cancellationToken)
    {
        await _productToAttributeCommandService.AddAttributesToProductAsync(request.ProductAttributes);
        return;

    }
}
