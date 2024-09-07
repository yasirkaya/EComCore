using EComCore.Domain.DTOs.CategoryDTO;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{

}