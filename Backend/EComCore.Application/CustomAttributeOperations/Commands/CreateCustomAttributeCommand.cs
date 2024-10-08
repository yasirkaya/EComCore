using EComCore.Domain.DTOs.AttributeDTO;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Commands;

public class CreateCustomAttributeCommand : IRequest<int>
{
    public string Name { get; set; }
}