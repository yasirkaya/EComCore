using EComCore.Domain.DTOs.AttributeValueDto;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Queries;

public class GetAttributeValuesQuery : IRequest<IEnumerable<AttributeValueDto>>
{

}