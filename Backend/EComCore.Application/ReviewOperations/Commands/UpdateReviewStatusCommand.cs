using EComCore.Domain.Enums;
using MediatR;

namespace EComCore.Application.ReviewOperations.Commands
{
    public class UpdateReviewStatusCommand : IRequest<bool>
    {
        public int Id { get; set; } 
        public ReviewStatus Status { get; set; } 
        public string ModerationReason { get; set; } 
    }
}