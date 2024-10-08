using EComCore.Domain.DTOs.AttributeValueDTO;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Queries;

public class GetAttributeValueByIdQuery : IRequest<AttributeValueDto>
{
    public int Id { get; set; }
}