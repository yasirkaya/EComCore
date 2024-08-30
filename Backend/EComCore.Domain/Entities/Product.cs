namespace EComCore.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
    public int StockQuantity { get; set; }
    public int GroupId { get; set; }
    public string ImageUrl { get; set; }
    public decimal Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<ProductToCategory> ProductToCategories { get; set; } = new List<ProductToCategory>();
    public ICollection<ProductToAttribute> ProductToAttributes { get; set; } = new List<ProductToAttribute>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

}