using MediatR;
using EComCore.Domain.DTOs.ReviewDTO;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetReviewsByUserIdQuery : IRequest<IEnumerable<ReviewDto>>
{
    public int UserId { get; set; }
}