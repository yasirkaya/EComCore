using EComCore.Domain.DTOs.CategoryDTO;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetSubCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
    public int Id { get; set; }
}