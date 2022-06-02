using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class Cateogries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroup_Category_CategoryID",
                table: "CategoryGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroup_Offers_OfferID",
                table: "CategoryGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGroup",
                table: "CategoryGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "CategoryGroup",
                newName: "CategoryGroups");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Catogories");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGroup_CategoryID",
                table: "CategoryGroups",
                newName: "IX_CategoryGroups_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGroups",
                table: "CategoryGroups",
                columns: new[] { "OfferID", "CategoryID" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroups_Offers_OfferID",
                table: "CategoryGroups",
                column: "OfferID",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroups_Catogories_CategoryID",
                table: "CategoryGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroups_Offers_OfferID",
                table: "CategoryGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catogories",
                table: "Catogories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGroups",
                table: "CategoryGroups");

            migrationBuilder.RenameTable(
                name: "Catogories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "CategoryGroups",
                newName: "CategoryGroup");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGroups_CategoryID",
                table: "CategoryGroup",
                newName: "IX_CategoryGroup_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGroup",
                table: "CategoryGroup",
                columns: new[] { "OfferID", "CategoryID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroup_Category_CategoryID",
                table: "CategoryGroup",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroup_Offers_OfferID",
                table: "CategoryGroup",
                column: "OfferID",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
