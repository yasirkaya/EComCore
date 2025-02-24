using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.Features.UserRoles.Queries
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, IEnumerable<UserRoleDetailsDto>>
    {
        private readonly IUserRoleQueryService _userRoleQueryService;

        public GetUserRolesQueryHandler(IUserRoleQueryService userRoleQueryService)
        {
            _userRoleQueryService = userRoleQueryService;
        }

        public async Task<IEnumerable<UserRoleDetailsDto>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            return await _userRoleQueryService.GetAllAsync();
        }
    }
}
