namespace EComCore.Domain.DTOs.ProductDTO;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
    public int StockQuantity { get; set; }
    public int GroupId { get; set; }
    public string ImageUrl { get; set; }
    public bool IsDeleted { get; set; }
}