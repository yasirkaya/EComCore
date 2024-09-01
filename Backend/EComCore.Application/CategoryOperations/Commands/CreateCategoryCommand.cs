using MediatR;

namespace EComCore.Application.CategoryOperations.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public DateTime CreatedAt { get; set; }
}