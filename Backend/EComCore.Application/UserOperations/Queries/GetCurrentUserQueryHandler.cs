using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserDetailsDto>
{
    private readonly IUserQueryService _userQueryService;
    public GetCurrentUserQueryHandler(IUserQueryService userQueryService)
    {
        _userQueryService = userQueryService;
    }

    public async Task<UserDetailsDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userQueryService.GetByEmailAsync(request.Email);
        return user;
    }
}