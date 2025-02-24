using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.Features.UserRoles.Queries
{
    public class GetUserRoleByRoleIdQueryHandler : IRequestHandler<GetUserRoleByRoleIdQuery, IEnumerable<UserRoleDetailsDto>>
    {
        private readonly IUserRoleQueryService _userRoleQueryService;

        public GetUserRoleByRoleIdQueryHandler(IUserRoleQueryService userRoleQueryService)
        {
            _userRoleQueryService = userRoleQueryService;
        }

        public async Task<IEnumerable<UserRoleDetailsDto>> Handle(GetUserRoleByRoleIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRoleQueryService.GetByRoleIdAsync(request.RoleId);
        }
    }
}
