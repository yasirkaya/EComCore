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
    public DbSet<CustomAttribute> Attributes { get; set; }
    public DbSet<AttributeValue> AttributeValues { get; set; }
    public DbSet<ProductToAttribute> ProductToAttributes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Addresses");

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

        modelBuilder.Entity<CustomAttribute>(entity =>
        {
            entity.ToTable("Attributes");

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
            entity.ToTable("AttributeValues");

            entity.HasKey(av => av.Id);

            entity.Property(av => av.Value)
                .IsRequired()
                .HasMaxLength(50);

        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");

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

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Members");

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

            entity.HasOne(m => m.User)
                .WithOne()
                .HasForeignKey<Member>(m => m.UserId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Orders");

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

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItems");

            entity.HasKey(oi => oi.Id);

            entity.Property(oi => oi.ProductName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(oi => oi.ProductDescription)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(oi => oi.ProductSku)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(oi => oi.Quantity)
                .IsRequired();

            entity.Property(oi => oi.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(oi => oi.CreatedAt)
                .IsRequired();

            entity.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payments");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.TransactionId)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(p => p.PaymentMethod)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(p => p.FailureReason)
                .HasMaxLength(500);

            entity.Property(p => p.CreatedAt)
                .IsRequired();

            entity.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Sku)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.StockQuantity)
                .IsRequired();

            entity.Property(p => p.GroupId)
                .IsRequired();

            entity.Property(p => p.ImageUrl)
                .HasMaxLength(1000);

            entity.Property(p => p.Rating)
                .IsRequired()
                .HasColumnType("decimal(3,2)");

            entity.Property(p => p.CreatedAt)
                .IsRequired();

            entity.HasMany(p => p.ProductToAttributes)
                .WithOne(pa => pa.Product)
                .HasForeignKey(pa => pa.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

        });

        modelBuilder.Entity<ProductToAttribute>(entity =>
        {
            entity.ToTable("ProductToAttributes");

            entity.HasKey(pta => pta.Id);

            entity.Property(pta => pta.ProductId)
                .IsRequired();

            entity.Property(pta => pta.AttributeId)
                .IsRequired();

            entity.Property(pta => pta.AttributeValueId)
                .IsRequired();

            entity.Property(pta => pta.CreatedAt)
                .IsRequired();

            entity.HasOne(pa => pa.Attribute)
                .WithMany()
                .HasForeignKey(pa => pa.AttributeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(pa => pa.AttributeValue)
                .WithMany()
                .HasForeignKey(pa => pa.AttributeValueId)
                .OnDelete(DeleteBehavior.Restrict);

        });

        modelBuilder.Entity<ProductToCategory>(entity =>
        {
            entity.ToTable("ProductToCategories");

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

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviews");

            entity.HasKey(r => r.Id);

            entity.Property(r => r.Rating)
               .IsRequired();

            entity.Property(r => r.Comment)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(r => r.Status)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(r => r.CreatedAt)
                .IsRequired();

            entity.HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.ToTable("Shipments");

            entity.HasKey(s => s.Id);

            entity.Property(s => s.TrackingNumber)
                .IsRequired()
                .HasMaxLength(12);

            entity.Property(s => s.Carrier)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(s => s.CreatedAt)
                .IsRequired();

            entity.HasOne(s => s.Order)
                .WithOne(o => o.Shipment)
                .HasForeignKey<Shipment>(s => s.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.ToTable("ShoppingCarts");

            entity.HasKey(sc => sc.Id);

            entity.Property(sc => sc.SessionId)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(sc => sc.CreatedAt)
                .IsRequired();

            entity.HasOne(sc => sc.Member)
                .WithOne(m => m.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc => sc.MemberId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ShoppingCartItem>(entity =>
        {
            entity.ToTable("ShoppingCartItems");

            entity.HasKey(sci => sci.Id);

            entity.Property(sci => sci.Quantity)
                .IsRequired();

            entity.Property(sci => sci.CreatedAt)
                .IsRequired();

            entity.HasOne(sci => sci.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartItems)
                .HasForeignKey(sci => sci.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(sci => sci.Product)
                .WithMany()
                .HasForeignKey(sci => sci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.HasKey(u => u.Id);

            entity.HasIndex(u => u.Email).IsUnique();

            entity.HasIndex(u => u.Username).IsUnique();

            entity.Property(u => u.Username)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(u => u.Email)
                .IsRequired();

            entity.Property(u => u.CreatedAt)
                .IsRequired();

        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");

            entity.HasKey(r => r.Id);

            entity.Property(r => r.Name)
                .IsRequired();

            entity.Property(r => r.CreatedAt)
                .IsRequired();
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRoles");

            entity.HasKey(ur => ur.Id);

            entity.HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired();
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(rp => rp.Id);

            entity.HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(rp => rp.Permission)
            .WithMany()
            .HasForeignKey(rp => rp.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
        });
    }
}