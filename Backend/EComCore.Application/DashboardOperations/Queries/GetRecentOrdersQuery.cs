using EComCore.Domain.DTOs.DashboardDTO;
using MediatR;

namespace EComCore.Application.DashboardOperations.Queries;

public class GetRecentOrdersQuery : IRequest<List<RecentOrderDto>>
{
}