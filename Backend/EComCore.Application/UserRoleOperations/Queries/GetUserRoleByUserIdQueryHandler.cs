using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.Features.UserRoles.Queries
{
    public class GetUserRoleByUserIdQueryHandler : IRequestHandler<GetUserRoleByUserIdQuery, IEnumerable<UserRoleDetailsDto>>
    {
        private readonly IUserRoleQueryService _userRoleQueryService;

        public GetUserRoleByUserIdQueryHandler(IUserRoleQueryService userRoleQueryService)
        {
            _userRoleQueryService = userRoleQueryService;
        }

        public async Task<IEnumerable<UserRoleDetailsDto>> Handle(GetUserRoleByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRoleQueryService.GetByUserIdAsync(request.UserId);
        }
    }
}
