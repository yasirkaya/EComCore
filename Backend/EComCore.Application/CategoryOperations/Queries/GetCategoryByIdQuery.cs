using EComCore.Domain.DTOs.CategoryDTO;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public int Id { get; set; }
}