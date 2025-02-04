using MediatR;
using EComCore.Domain.DTOs.ReviewDTO;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetReviewsByProductIdQuery : IRequest<IEnumerable<ReviewDto>>
{
    public int ProductId { get; set; }
}