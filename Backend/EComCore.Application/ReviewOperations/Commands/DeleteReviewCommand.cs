using MediatR;

namespace EComCore.Application.ReviewOperations.Commands;

public class DeleteReviewCommand : IRequest<bool>
{
    public int Id { get; set; }
}