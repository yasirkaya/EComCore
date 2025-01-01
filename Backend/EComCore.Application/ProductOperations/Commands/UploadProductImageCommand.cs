using MediatR;
using Microsoft.AspNetCore.Http;

namespace EComCore.Application.ProductOperations.Commands;

public class UploadProductImageCommand : IRequest<string>
{
    public int ProductId { get; set; }
    public IFormFile Image { get; set; }
}