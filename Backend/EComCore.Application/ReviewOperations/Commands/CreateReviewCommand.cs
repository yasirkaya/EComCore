using MediatR;

namespace EComCore.Application.ReviewOperations.Commands;

public class CreateReviewCommand : IRequest<int>
{
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
}