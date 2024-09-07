using EComCore.Domain.DTOs.AttributeDTO;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class GetCustomAttributesQuery : IRequest<IEnumerable<CustomAttributeDto>>
{

}