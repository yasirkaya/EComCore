using System.Reflection;
using MediatR;
using EComCore.Application.Mappers;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Repositories;
using EComCore.Application.CategoryOperations.Commands;
using EComCore.Domain.Services.Commands;
using EComCore.Application.Services.Commands;
using EComCore.Domain.Services.Queries;
using EComCore.Application.CategoryOperations.Queries;
using EComCore.Application.CustomAttributeOperations.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EComCore.Domain.Services.Shared;
using EComCore.Application.Services.Shared;
using EComCore.Infrastructure.Services;
using EComCore.Domain.Configurations;
using EComCore.Application.CartOperations.Commands;
using EComCore.Application.CartOperations.Queries;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Application.Services.Queries;
using EComCore.Application.OrderOperations.Commands;
using EComCore.Application.OrderOperations.Queries;
using EComCore.Domain.DTOs.OrderDTO;
using EComCore.Application.AuthOperations.Commands;
using EComCore.Application.Services.Auth;
using EComCore.Domain.Services.Auth;
using EComCore.ınfrastructure.Repositories;
using EComCore.Application.Services.Dashboard;

namespace EComCore.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Ortam değişkenlerini yükle
        builder.Configuration.AddEnvironmentVariables();

        // CORS politikasını ekle
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        // Add services to the container.
        builder.Services.AddDbContext<EComCoreDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("EComCoreDatabase")));


        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));

        // Repository registrations
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IAttributeRepository, AttributeRepository>();
        builder.Services.AddScoped<IAttributeValueRepository, AttributeValueRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductToAttributeRepository, ProductToAttributeRepository>();
        builder.Services.AddScoped<IProductToCategoryRepository, ProductToCategoryRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IAddressRepository, AddressRepository>();
        builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
        builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();


        // Service registrations
        builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
        builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
        builder.Services.AddScoped<ICustomAttributeCommandService, CustomAttributeCommandService>();
        builder.Services.AddScoped<ICustomAttributeQueryService, CustomAttributeQueryService>();
        builder.Services.AddScoped<IAttributeValueCommandService, AttributeValueCommandService>();
        builder.Services.AddScoped<IAttributeValueQueryService, AttributeValueQueryService>();
        builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
        builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
        builder.Services.AddScoped<IProductToAttributeCommandService, ProductToAttributeCommandService>();
        builder.Services.AddScoped<IProductToAttributeQueryService, ProductToAttributeQueryService>();
        builder.Services.AddScoped<IProductToCategoryCommandService, ProductToCategoryCommandService>();
        builder.Services.AddScoped<IProductToCategoryQueryService, ProductToCategoryQueryService>();
        builder.Services.AddScoped<IUserCommandService, UserCommandService>();
        builder.Services.AddScoped<IUserQueryService, UserQueryService>();
        builder.Services.AddScoped<IRoleQueryService, RoleQueryService>();
        builder.Services.AddScoped<IRoleCommandService, RoleCommandService>();
        builder.Services.AddScoped<IUserRoleCommandService, UserRoleCommandService>();
        builder.Services.AddScoped<IUserRoleQueryService, UserRoleQueryService>();
        builder.Services.AddScoped<ICartCommandService, CartCommandService>();
        builder.Services.AddScoped<ICartQueryService, CartQueryService>();
        builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
        builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();
        builder.Services.AddScoped<IAddressCommandService, AddressCommandService>();
        builder.Services.AddScoped<IAddressQueryService, AddressQueryService>();
        builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
        builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
        builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();
        builder.Services.AddScoped<IPermissionCommandService, PermissionCommandService>();
        builder.Services.AddScoped<IPermissionQueryService, PermissionQueryService>();
        builder.Services.AddScoped<IRolePermissionCommandService, RolePermissionCommandService>();
        builder.Services.AddScoped<IRolePermissionQueryService, RolePermissionQueryService>();
        builder.Services.AddScoped<IDashboardQueryService, DashboardQueryService>();

        builder.Services.AddScoped<IJwtService, JwtService>();
        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddScoped<IReviewAnalysisService, ReviewAnalysisService>();

        builder.Services.AddHttpClient();

        // Configure EmailService
        builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailSettings"));

        // Auth Services
        builder.Services.AddScoped<IAuthCommandService, AuthCommandService>();
        builder.Services.AddScoped<IAuthQueryService, AuthQueryService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["Secret"] ?? throw new InvalidOperationException("JWT Secret key is not configured");

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ClockSkew = TimeSpan.Zero // Token süresini tam doğru şekilde kontrol eder
            };
        });

        builder.Services.AddAuthorization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // CORS middleware'ini ekle
        app.UseCors("AllowAll");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
