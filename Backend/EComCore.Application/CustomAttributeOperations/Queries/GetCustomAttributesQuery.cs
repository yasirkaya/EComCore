using EComCore.Domain.DTOs.AttributeDto;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class GetCustomAttributesQuery : IRequest<IEnumerable<CustomAttributeDto>>
{

}