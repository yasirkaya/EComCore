using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Auth;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserDto>
{
    private readonly IAuthQueryService _authQueryService;

    public GetCurrentUserQueryHandler(IAuthQueryService authQueryService)
    {
        _authQueryService = authQueryService;
    }

    public async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        return await _authQueryService.GetCurrentUserAsync(request.Email);
    }
}