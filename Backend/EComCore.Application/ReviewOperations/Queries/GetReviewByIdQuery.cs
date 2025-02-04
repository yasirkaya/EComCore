using EComCore.Domain.DTOs.ReviewDTO;
using MediatR;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetReviewByIdQuery : IRequest<ReviewDto>
{
    public int Id { get; set; }
}
