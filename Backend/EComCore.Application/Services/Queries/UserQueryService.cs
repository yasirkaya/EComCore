using AutoMapper;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;
    public UserQueryService(IUserRoleRepository userRoleRepository, IMapper mapper)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }
}