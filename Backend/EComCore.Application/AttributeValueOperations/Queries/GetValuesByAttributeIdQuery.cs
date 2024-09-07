using EComCore.Domain.DTOs.AttributeValueDTO;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Queries;

public class GetValuesByAttributeIdQuery : IRequest<IEnumerable<AttributeValueDto>>
{
    public int AttributeId { get; set; }
}