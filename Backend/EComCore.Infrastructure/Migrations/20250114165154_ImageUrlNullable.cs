using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EComCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrlNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_BillingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressId",
                table: "Orders",
                newName: "ShipmentId");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "BillingAddressId",
                table: "Orders",
                newName: "PaymentId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderItems",
                newName: "UnitPrice");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders",
                column: "ShipmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipments_ShipmentId",
                table: "Orders",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipments_ShipmentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "Orders",
                newName: "ShippingAddressId");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Orders",
                newName: "BillingAddressId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderItems",
                newName: "Price");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ShoppingCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
