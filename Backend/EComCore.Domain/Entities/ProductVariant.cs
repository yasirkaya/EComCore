namespace EComCore.Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public ICollection<ProductVariantAttribute> ProductVariantAttributes { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}