using EComCore.Domain.DTOs.ProductToCategoryDTO;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Queries;

public class GetProductsByCategoryIdQuery : IRequest<IEnumerable<ProductToCategoryDto>>
{
    public int CategoryId { get; set; }
}