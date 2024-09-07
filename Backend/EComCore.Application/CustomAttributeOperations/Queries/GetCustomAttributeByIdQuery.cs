using EComCore.Domain.DTOs.AttributeDTO;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class GetCustomAttributeByIdQuery : IRequest<CustomAttributeDto>
{
    public int Id { get; set; }
}