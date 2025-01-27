using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EComCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAddressRelationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_BillingAddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_ShippingAddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BillingAddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ShippingAddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BillingAddressId",
                table: "Users",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShippingAddressId",
                table: "Users",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_BillingAddressId",
                table: "Users",
                column: "BillingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_ShippingAddressId",
                table: "Users",
                column: "ShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
