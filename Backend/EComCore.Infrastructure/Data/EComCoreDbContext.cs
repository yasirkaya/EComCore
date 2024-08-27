using Microsoft.EntityFrameworkCore;
using EComCore.Domain.Entities;


namespace EComCore.Infrastructure.Data;

public class EComCoreDbContext : DbContext
{
    public EComCoreDbContext(DbContextOptions<EComCoreDbContext> options) : base(options)
    {
    }


    public DbSet<Member> Members { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductToCategory> ProductToCategories { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Domain.Entities.Attribute> Attributes { get; set; }
    public DbSet<AttributeValue> AttributeValues { get; set; }
    public DbSet<ProductToAttribute> ProductToAttributes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //kuralları yazmaya devam edeceğim...
    }
}