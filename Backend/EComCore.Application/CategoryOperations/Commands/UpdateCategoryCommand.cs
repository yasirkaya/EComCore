using MediatR;

namespace EComCore.Application.CategoryOperations.Commands;

public class UpdateCategoryCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public DateTime UpdatedAt { get; set; }
}