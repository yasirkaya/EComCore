namespace EComCore.Domain.DTOs.ProductToCategoryDTO;

public class UpdateProductToCategoryDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
}