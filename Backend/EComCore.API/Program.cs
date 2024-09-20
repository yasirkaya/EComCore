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

namespace EComCore.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<EComCoreDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("EComCoreDatabase")));
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IAttributeRepository, AttributeRepository>();
        builder.Services.AddScoped<IAttributeValueRepository, AttributeValueRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductToAttributeRepository, ProductToAttributeRepository>();
        builder.Services.AddScoped<IProductToCategoryRepository, ProductToCategoryRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

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


        builder.Services.AddScoped<IJwtService, JwtService>();



        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["Secret"];

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

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
