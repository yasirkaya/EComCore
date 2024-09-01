using MediatR;

namespace EComCore.Application.CategoryOperations.Commands;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
}