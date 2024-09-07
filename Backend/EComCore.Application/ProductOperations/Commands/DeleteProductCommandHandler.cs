using AutoMapper;
using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductOperations.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductCommandService _productCommandService;
    private readonly IMapper _mapper;
    public DeleteProductCommandHandler(IProductCommandService productCommandService, IMapper mapper)
    {
        _productCommandService = productCommandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productCommandService.SoftDelete(_mapper.Map<DeleteProductDto>(request));
        return;
    }
}