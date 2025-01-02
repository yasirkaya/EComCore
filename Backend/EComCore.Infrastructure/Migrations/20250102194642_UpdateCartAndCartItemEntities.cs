using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EComCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartAndCartItemEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ShoppingCartItems",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ShoppingCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ShoppingCartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShoppingCartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "ShoppingCartItems",
                newName: "Price");
        }
    }
}
