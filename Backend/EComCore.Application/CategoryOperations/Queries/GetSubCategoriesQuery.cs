using EComCore.Domain.DTOs.CategoryDto;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetSubCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
    public int Id { get; set; }
}