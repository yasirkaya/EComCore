using EComCore.Domain.Entities;
using EComCore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace EComCore.Infrastructure.Data.Seed;

public static class DataSeeder
{
    private static readonly Random _random = new Random();
    private static readonly string[] _productNames = {
        "iPhone", "Samsung", "Xiaomi", "Huawei", "Oppo", "Vivo", "Sony", "LG", "Nokia", "OnePlus",
        "MacBook", "Dell", "HP", "Lenovo", "Asus", "Acer", "MSI", "Razer", "Alienware", "MacBook Pro",
        "iPad", "Galaxy Tab", "Surface Pro", "iPad Pro", "Fire HD", "Kindle", "Nexus", "Pixel Slate",
        "Apple Watch", "Galaxy Watch", "Fitbit", "Garmin", "Xiaomi Band", "Huawei Watch", "Amazfit"
    };

    private static readonly string[] _productDescriptions = {
        "Yüksek performanslı", "Premium", "Ultra", "Pro", "Max", "Plus", "Lite", "Mini", "Air", "Edge",
        "5G", "4K", "OLED", "AMOLED", "Retina", "HDR", "Dolby", "Stereo", "Wireless", "Bluetooth"
    };

    private static readonly string[] _cities = {
        "İstanbul", "Ankara", "İzmir", "Bursa", "Antalya", "Adana", "Konya", "Gaziantep", "Mersin", "Diyarbakır"
    };

    public static async Task SeedData(EComCoreDbContext context)
    {
        // Mevcut rolleri ve izinleri kontrol et
        if (!await context.Roles.AnyAsync())
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin", CreatedAt = DateTime.UtcNow },
                new Role { Name = "User", CreatedAt = DateTime.UtcNow },
                new Role { Name = "Manager", CreatedAt = DateTime.UtcNow }
            };
            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }

        // Admin kullanıcısını ekle
        if (!await context.Users.AnyAsync(u => u.Email == "admin@example.com"))
        {
            var adminRole = await context.Roles.FirstAsync(r => r.Name == "Admin");
            var adminUser = new User
            {
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                IsActive = true,
                IsEmailVerified = true,
                CreatedAt = DateTime.UtcNow
            };
            await context.Users.AddAsync(adminUser);
            await context.SaveChangesAsync();

            var userRole = new UserRole
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };
            await context.UserRoles.AddAsync(userRole);
            await context.SaveChangesAsync();
        }

        // 100 adet ürün ekle
        if (await context.Products.CountAsync() < 100)
        {
            var categories = await context.Categories.ToListAsync();
            var products = new List<Product>();

            for (int i = 0; i < 100; i++)
            {
                var randomCategory = categories[_random.Next(categories.Count)];
                var productName = _productNames[_random.Next(_productNames.Length)];
                var description = _productDescriptions[_random.Next(_productDescriptions.Length)];
                var price = _random.Next(1000, 50000);
                var stock = _random.Next(10, 200);
                var rating = _random.Next(35, 50) / 10.0m;

                var product = new Product
                {
                    Name = $"{productName} {description} {i + 1}",
                    Description = $"{description} {productName} ürünü. Yüksek kalite ve performans.",
                    Price = price,
                    Sku = $"SKU-{i + 1:D4}",
                    StockQuantity = stock,
                    GroupId = 1,
                    ImageUrl = $"https://example.com/{productName.ToLower()}-{i + 1}.jpg",
                    Rating = rating,
                    CreatedAt = DateTime.UtcNow
                };
                products.Add(product);
            }

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // Ürünleri kategorilere dağıt
            var productToCategories = new List<ProductToCategory>();
            foreach (var product in products)
            {
                var randomCategory = categories[_random.Next(categories.Count)];
                productToCategories.Add(new ProductToCategory
                {
                    ProductId = product.Id,
                    CategoryId = randomCategory.Id,
                    CreatedAt = DateTime.UtcNow
                });
            }
            await context.ProductToCategories.AddRangeAsync(productToCategories);
            await context.SaveChangesAsync();
        }

        // 50 adet sipariş ekle
        if (await context.Orders.CountAsync() < 50)
        {
            var users = await context.Users.ToListAsync();
            var products = await context.Products.ToListAsync();

            for (int i = 0; i < 50; i++)
            {
                var randomUser = users[_random.Next(users.Count)];
                var randomCity = _cities[_random.Next(_cities.Length)];

                var address = new Address
                {
                    UserId = randomUser.Id,
                    Name = "Ev",
                    AddressLine1 = $"Örnek Mahallesi, Test Sokak No:{i + 1}",
                    City = randomCity,
                    PostalCode = "34000",
                    CreatedAt = DateTime.UtcNow
                };
                await context.Addresses.AddAsync(address);
                await context.SaveChangesAsync();

                var orderStatus = (OrderStatus)_random.Next(0, 4); // 0-3 arası sipariş durumu
                var orderDate = DateTime.UtcNow.AddDays(-_random.Next(0, 30)); // Son 30 gün içinde

                var order = new Order
                {
                    UserId = randomUser.Id,
                    AddressId = address.Id,
                    TotalAmount = 0,
                    OrderStatus = orderStatus,
                    CreatedAt = orderDate
                };
                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();

                // Her siparişe 1-5 arası ürün ekle
                var orderItems = new List<OrderItem>();
                var orderItemCount = _random.Next(1, 6);
                decimal totalAmount = 0;

                for (int j = 0; j < orderItemCount; j++)
                {
                    var randomProduct = products[_random.Next(products.Count)];
                    var quantity = _random.Next(1, 4);
                    var unitPrice = randomProduct.Price;
                    var totalPrice = unitPrice * quantity;
                    totalAmount += totalPrice;

                    orderItems.Add(new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = randomProduct.Id,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        TotalPrice = totalPrice,
                        CreatedAt = orderDate
                    });
                }

                // Sipariş toplam tutarını güncelle
                order.TotalAmount = totalAmount;
                await context.OrderItems.AddRangeAsync(orderItems);
                await context.SaveChangesAsync();
            }
        }
    }
}