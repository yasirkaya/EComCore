using MediatR;

namespace EComCore.Application.Services.CategoryOperations.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public CreateCategoryCommand()
    {
        CreatAt = DateTime.UtcNow;
    }

    public string Name { get; set; }
    public int? ParentId { get; set; }
    public DateTime CreatAt { get; set; }
}