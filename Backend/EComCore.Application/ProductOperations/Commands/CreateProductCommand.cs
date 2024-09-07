using MediatR;

namespace EComCore.Application.ProductOperations.Commands;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
    public int StockQuantity { get; set; }
    public int GroupId { get; set; }
    public string ImageUrl { get; set; }
}