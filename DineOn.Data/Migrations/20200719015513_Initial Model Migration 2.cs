using Microsoft.EntityFrameworkCore.Migrations;

namespace DineOn.Data.Migrations
{
    public partial class InitialModelMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_MenuItems_ItemOnMenuMenuItemId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_ItemOnMenuMenuItemId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ItemOnMenuMenuItemId",
                table: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Rating",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_MenuItemId",
                table: "Rating",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_MenuItems_MenuItemId",
                table: "Rating",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_MenuItems_MenuItemId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_MenuItemId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "ItemOnMenuMenuItemId",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ItemOnMenuMenuItemId",
                table: "Rating",
                column: "ItemOnMenuMenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_MenuItems_ItemOnMenuMenuItemId",
                table: "Rating",
                column: "ItemOnMenuMenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
