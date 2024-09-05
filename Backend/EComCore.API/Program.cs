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

        builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
        builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
        builder.Services.AddScoped<ICustomAttributeCommandService, CustomAttributeCommandService>();
        builder.Services.AddScoped<ICustomAttributeQueryService, CustomAttributeQueryService>();
        builder.Services.AddScoped<IAttributeValueCommandService, AttributeValueCommandService>();


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
