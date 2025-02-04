using MediatR;
using EComCore.Domain.DTOs.ReviewDTO;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetPendingReviewsQuery : IRequest<IEnumerable<ReviewDto>>
{
}