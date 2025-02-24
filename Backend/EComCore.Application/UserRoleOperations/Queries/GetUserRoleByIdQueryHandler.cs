using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.Features.UserRoles.Queries
{
    public class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQuery, UserRoleDetailsDto>
    {
        private readonly IUserRoleQueryService _userRoleQueryService;

        public GetUserRoleByIdQueryHandler(IUserRoleQueryService userRoleQueryService)
        {
            _userRoleQueryService = userRoleQueryService;
        }

        public async Task<UserRoleDetailsDto> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRoleQueryService.GetByIdAsync(request.Id);
        }
    }
}
