using EComCore.Domain.DTOs.AttributeValueDTO;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Queries;

public class GetAttributeValuesQuery : IRequest<IEnumerable<AttributeValueDto>>
{

}