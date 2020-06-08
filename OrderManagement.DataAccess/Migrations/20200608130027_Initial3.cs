using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.DataAccess.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderEntityId",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderEntityId",
                table: "OrderItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
