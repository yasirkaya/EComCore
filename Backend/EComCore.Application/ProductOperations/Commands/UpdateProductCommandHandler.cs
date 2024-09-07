using AutoMapper;
using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductOperations.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductCommandService _productCommandService;
    private readonly IMapper _mapper;
    public UpdateProductCommandHandler(IProductCommandService productCommandService, IMapper mapper)
    {
        _productCommandService = productCommandService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<UpdateProductDto>(request);
        await _productCommandService.UpdateAsync(product);
        return;
    }
}