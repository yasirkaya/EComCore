namespace EComCore.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string SKU { get; set; }
    public int StockQuantity { get; set; }
    public int GroupId { get; set; }
    public string ImageUrl { get; set; }
    public decimal Rating { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<ProductToCategory> ProductToCategories { get; set; }
    public ICollection<ProductVariant> ProductVariants { get; set; }
    public ICollection<Review> Reviews { get; set; }
}