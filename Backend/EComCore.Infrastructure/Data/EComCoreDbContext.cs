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

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(c => c.Parent)
                .WithMany(pc => pc.SubCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(c => c.CreatedAt)
                .IsRequired();

        });

        modelBuilder.Entity<ProductToCategory>(entity =>
        {
            entity.HasKey(pc => pc.Id);

            entity.Property(pc => pc.CreatedAt)
                .IsRequired();

            entity.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductToCategories)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(pc => pc.Category)
                .WithMany(c => c.ProductToCategories)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(a => a.AddressLine1)
                .HasMaxLength(200);

            entity.Property(a => a.AddressLine2)
                .HasMaxLength(200);

            entity.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(a => a.CreatedAt)
                .IsRequired();
        });

        modelBuilder.Entity<Domain.Entities.Attribute>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(a => a.CreatedAt)
                .IsRequired();

            entity.HasMany(a => a.AttributeValues)
                .WithOne(av => av.Attribute)
                .HasForeignKey(av => av.AttributeId)
                .OnDelete(DeleteBehavior.Restrict);

        });

        modelBuilder.Entity<AttributeValue>(entity =>
        {
            entity.HasKey(av => av.Id);

            entity.Property(av => av.Value)
                .IsRequired()
                .HasMaxLength(50);

        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(m => m.Id);

            entity.Property(m => m.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(m => m.LastName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(m => m.PhoneNumber)
                .HasMaxLength(11);

            entity.Property(m => m.Email)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(m => m.CreatedAt)
                .IsRequired();

            entity.HasOne(m => m.BillingAddress)
                .WithMany()
                .HasForeignKey(m => m.BillingAddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            entity.HasOne(m => m.ShippingAddress)
                .WithMany()
                .HasForeignKey(m => m.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            entity.HasMany(m => m.Orders)
                .WithOne(o => o.Member)
                .HasForeignKey(o => o.MemberId);

            entity.HasMany(m => m.Reviews)
                .WithOne(r => r.Member)
                .HasForeignKey(r => r.MemberId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.SessionId)
                .HasMaxLength(100);

            entity.Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(o => o.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(o => o.Status)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(o => o.PaymentStatus)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(o => o.FailureReason)
                .HasMaxLength(255);

            entity.Property(o => o.CreatedAt)
                .IsRequired();

            entity.HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(o => o.OrderItems)
               .WithOne(oi => oi.Order)
               .HasForeignKey(oi => oi.OrderId);
        });
    }
}