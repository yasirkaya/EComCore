using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EComCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveShipmentIdInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId2",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipments_ShipmentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaymentId2",
                table: "Orders",
                newName: "ShipmentId2");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaymentId2",
                table: "Orders",
                newName: "IX_Orders_ShipmentId2");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId1",
                table: "Orders",
                column: "PaymentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId1",
                table: "Orders",
                column: "PaymentId1",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipments_ShipmentId2",
                table: "Orders",
                column: "ShipmentId2",
                principalTable: "Shipments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipments_ShipmentId2",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentId1",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShipmentId2",
                table: "Orders",
                newName: "PaymentId2");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShipmentId2",
                table: "Orders",
                newName: "IX_Orders_PaymentId2");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders",
                column: "ShipmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId2",
                table: "Orders",
                column: "PaymentId2",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipments_ShipmentId",
                table: "Orders",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
