using Microsoft.EntityFrameworkCore.Migrations;

namespace DineOn.Data.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderReference",
                table: "OrderItems");

            migrationBuilder.AddColumn<bool>(
                name: "OrderCompleted",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCompleted",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderReference",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
