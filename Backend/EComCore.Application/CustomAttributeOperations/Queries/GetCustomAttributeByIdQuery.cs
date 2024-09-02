using EComCore.Domain.DTOs.AttributeDto;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class GetCustomAttributeByIdQuery : IRequest<CustomAttributeDto>
{
    public int Id { get; set; }
}