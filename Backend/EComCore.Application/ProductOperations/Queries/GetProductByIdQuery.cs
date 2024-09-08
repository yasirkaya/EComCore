using EComCore.Domain.DTOs.ProductDTO;
using MediatR;

namespace EComCore.Application.ProductOperations.Queries;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}