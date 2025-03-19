using EComCore.Domain.Entities;
using EComCore.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Data.Seed;

public static class DataSeeder
{
    private static readonly Random _random = new Random();

    // Örnek veri listeleri
    private static readonly string[] _firstNames = { "Ahmet", "Mehmet", "Ayşe", "Fatma", "Ali", "Zeynep", "Can", "Ece" };
    private static readonly string[] _lastNames = { "Yılmaz", "Demir", "Kaya", "Çelik", "Şahin", "Öztürk" };
    private static readonly string[] _cities = { "İstanbul", "Ankara", "İzmir", "Bursa", "Antalya" };

    private static readonly string[] _productNames = {
        "iPhone 15", "Samsung Galaxy S24", "MacBook Pro", "Asus ROG", "Sony TV",
        "iPad Air", "Apple Watch", "AirPods Pro", "PlayStation 5", "Xbox Series X"
    };

    public static async Task SeedDataAsync(EComCoreDbContext context)
    {
        // Önce rolleri ekle
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

        // Kullanıcıları ekle
        if (!await context.Users.AnyAsync())
        {
            var users = CreateUsers(20);
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();

            // Kullanıcı-Rol ilişkilerini ekle
            var userRoles = new List<UserRole>();
            var roles = await context.Roles.ToListAsync();
            var adminRole = roles.First(r => r.Name == "Admin");
            var userRole = roles.First(r => r.Name == "User");

            foreach (var user in users)
            {
                // İlk kullanıcıyı admin yap
                if (user == users.First())
                {
                    userRoles.Add(new UserRole
                    {
                        UserId = user.Id,
                        RoleId = adminRole.Id,
                    });
                }

                // Tüm kullanıcılara User rolü ver
                userRoles.Add(new UserRole
                {
                    UserId = user.Id,
                    RoleId = userRole.Id,
                });
            }

            await context.UserRoles.AddRangeAsync(userRoles);
            await context.SaveChangesAsync();

            // Adresleri ekle
            var addresses = users.SelectMany(u => CreateAddresses(u.Id, 2)).ToList();
            await context.Addresses.AddRangeAsync(addresses);
            await context.SaveChangesAsync();
        }

        // Kategorileri ekle
        if (!await context.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new Category { Name = "Telefonlar", CreatedAt = DateTime.UtcNow },
                new Category { Name = "Bilgisayarlar", CreatedAt = DateTime.UtcNow },
                new Category { Name = "Tabletler", CreatedAt = DateTime.UtcNow },
                new Category { Name = "Akıllı Saatler", CreatedAt = DateTime.UtcNow }
            };
            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }

        // Ürünleri ekle
        if (!await context.Products.AnyAsync())
        {
            var products = CreateProducts(50);
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // Ürün-Kategori ilişkilerini ekle
            var productToCategories = new List<ProductToCategory>();
            var categories = await context.Categories.ToListAsync();

            foreach (var product in products)
            {
                // Her ürünü rastgele 1-2 kategoriye ekle
                var categoryCount = _random.Next(1, 3);
                var selectedCategories = categories.OrderBy(x => Guid.NewGuid()).Take(categoryCount);

                foreach (var category in selectedCategories)
                {
                    productToCategories.Add(new ProductToCategory
                    {
                        ProductId = product.Id,
                        CategoryId = category.Id,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            await context.ProductToCategories.AddRangeAsync(productToCategories);
            await context.SaveChangesAsync();
        }

        // Siparişleri ekle
        if (!await context.Orders.AnyAsync())
        {
            var users = await context.Users.Include(u => u.Addresses).ToListAsync();
            var products = await context.Products.ToListAsync();
            var orders = CreateOrders(users, products, 100); // 100 sipariş oluştur
            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
    }

    private static List<User> CreateUsers(int count)
    {
        var users = new List<User>();
        for (int i = 0; i < count; i++)
        {
            var firstName = _firstNames[_random.Next(_firstNames.Length)];
            var lastName = _lastNames[_random.Next(_lastNames.Length)];
            users.Add(new User
            {
                Username = $"{firstName.ToLower()}{i}",
                Email = $"{firstName.ToLower()}{i}@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Test123!"),
                IsActive = true,
                IsEmailVerified = true,
                CreatedAt = DateTime.UtcNow
            });
        }
        return users;
    }

    private static List<Address> CreateAddresses(int userId, int count)
    {
        var addresses = new List<Address>();
        for (int i = 0; i < count; i++)
        {
            var city = _cities[_random.Next(_cities.Length)];
            addresses.Add(new Address
            {
                UserId = userId,
                Name = i == 0 ? "Ev" : "İş",
                AddressLine1 = $"Test Mahallesi, {_random.Next(1, 100)}. Sokak No:{_random.Next(1, 50)}",
                City = city,
                PostalCode = $"{_random.Next(10000, 99999)}",
                CreatedAt = DateTime.UtcNow
            });
        }
        return addresses;
    }

    private static List<Product> CreateProducts(int count)
    {
        var products = new List<Product>();
        for (int i = 0; i < count; i++)
        {
            var name = _productNames[_random.Next(_productNames.Length)];
            var price = _random.Next(1000, 50000);
            products.Add(new Product
            {
                Name = $"{name} Model {i + 1}",
                Description = $"{name} için detaylı açıklama metni",
                Price = price,
                Sku = $"SKU-{i + 1:D5}",
                StockQuantity = _random.Next(10, 100),
                GroupId = 1,
                Rating = _random.Next(35, 50) / 10.0m,
                CreatedAt = DateTime.UtcNow
            });
        }
        return products;
    }

    private static List<Order> CreateOrders(List<User> users, List<Product> products, int count)
    {
        var orders = new List<Order>();
        for (int i = 0; i < count; i++)
        {
            var user = users[_random.Next(users.Count)];
            var address = user.Addresses.First();
            var orderDate = DateTime.UtcNow.AddDays(-_random.Next(1, 30));

            var order = new Order
            {
                UserId = user.Id,
                AddressId = address.Id,
                OrderStatus = (OrderStatus)_random.Next(0, 4),
                CreatedAt = orderDate,
                OrderItems = CreateOrderItems(products, _random.Next(1, 5)) // 1-5 arası ürün
            };

            // Toplam tutarı hesapla
            order.TotalAmount = order.OrderItems.Sum(item => item.TotalPrice);
            orders.Add(order);
        }
        return orders;
    }

    private static List<OrderItem> CreateOrderItems(List<Product> products, int count)
    {
        var items = new List<OrderItem>();
        var selectedProducts = products.OrderBy(x => Guid.NewGuid()).Take(count).ToList();

        foreach (var product in selectedProducts)
        {
            var quantity = _random.Next(1, 4);
            items.Add(new OrderItem
            {
                ProductId = product.Id,
                Quantity = quantity,
                UnitPrice = product.Price,
                TotalPrice = product.Price * quantity,
                CreatedAt = DateTime.UtcNow
            });
        }
        return items;
    }
}