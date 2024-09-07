using MediatR;

namespace EComCore.Application.ProductOperations.Commands;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}