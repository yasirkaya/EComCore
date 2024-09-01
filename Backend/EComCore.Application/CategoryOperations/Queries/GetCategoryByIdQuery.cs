using EComCore.Domain.DTOs.CategoryDto;
using MediatR;

namespace EComCore.Application.CategoryOperations.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public int Id { get; set; }
}