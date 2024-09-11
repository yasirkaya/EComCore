using EComCore.Domain.DTOs.ProductToCategoryDTO;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Queries;

public class GetProductToCategoriesQuery : IRequest<IEnumerable<ProductToCategoryDto>>
{

}