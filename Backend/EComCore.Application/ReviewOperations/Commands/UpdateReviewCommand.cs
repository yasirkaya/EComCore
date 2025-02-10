using EComCore.Domain.Enums;
using MediatR;

namespace EComCore.Application.ReviewOperations.Commands;

public class UpdateReviewCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int? Rating { get; set; }
    public string? Comment { get; set; }
    public ReviewStatus? Status { get; set; }
    public string? ModerationReason { get; set; }
}