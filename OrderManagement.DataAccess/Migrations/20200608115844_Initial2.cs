using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.DataAccess.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItems_Name",
                table: "OrderItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Name",
                table: "OrderItems",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
