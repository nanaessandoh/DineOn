using Microsoft.EntityFrameworkCore.Migrations;

namespace DineOn.Data.Migrations
{
    public partial class InitialModelMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_MenuItems_MenuItemId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_MenuItemId",
                table: "Ratings",
                newName: "IX_Ratings_MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_MenuItems_MenuItemId",
                table: "Ratings",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_MenuItems_MenuItemId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MenuItemId",
                table: "Rating",
                newName: "IX_Rating_MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_MenuItems_MenuItemId",
                table: "Rating",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
