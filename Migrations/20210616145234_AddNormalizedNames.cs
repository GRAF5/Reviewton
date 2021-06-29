using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsReviewsAngular.Migrations
{
    public partial class AddNormalizedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_Products_productidProduct",
                table: "AtributeValues");

            migrationBuilder.AddColumn<string>(
                name: "normalizedName",
                table: "Producers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "normalizedName",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_Products_productidProduct",
                table: "AtributeValues",
                column: "productidProduct",
                principalTable: "Products",
                principalColumn: "idProduct",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_Products_productidProduct",
                table: "AtributeValues");

            migrationBuilder.DropColumn(
                name: "normalizedName",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "normalizedName",
                table: "Countries");

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_Products_productidProduct",
                table: "AtributeValues",
                column: "productidProduct",
                principalTable: "Products",
                principalColumn: "idProduct");
        }
    }
}
