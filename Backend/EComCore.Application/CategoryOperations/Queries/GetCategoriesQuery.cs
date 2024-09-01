using EComCore.Domain.DTOs.CategoryDto;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{

}