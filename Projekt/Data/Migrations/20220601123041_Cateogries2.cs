using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class Cateogries2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroups_Catogories_CategoryID",
                table: "CategoryGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catogories",
                table: "Catogories");

            migrationBuilder.RenameTable(
                name: "Catogories",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroups_Categories_CategoryID",
                table: "CategoryGroups",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroups_Categories_CategoryID",
                table: "CategoryGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Catogories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catogories",
                table: "Catogories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroups_Catogories_CategoryID",
                table: "CategoryGroups",
                column: "CategoryID",
                principalTable: "Catogories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
