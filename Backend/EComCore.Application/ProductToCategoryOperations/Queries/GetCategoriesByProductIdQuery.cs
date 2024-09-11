using EComCore.Domain.DTOs.ProductToCategoryDTO;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Queries;

public class GetCategoriesByProductIdQuery : IRequest<IEnumerable<ProductToCategoryDto>>
{
    public int ProductId { get; set; }
}