using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsReviewsAngular.Migrations
{
    public partial class AddNormalizedValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_AtributeValues_parentidAtribute_parentvalue",
                table: "AtributeValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtributeValues",
                table: "AtributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AtributeValues_parentidAtribute_parentvalue",
                table: "AtributeValues");

            migrationBuilder.DropColumn(
                name: "parentvalue",
                table: "AtributeValues");

            migrationBuilder.AddColumn<string>(
                name: "normalizedName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "AtributeValues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "normalizedValue",
                table: "AtributeValues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "parentnormalizedValue",
                table: "AtributeValues",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtributeValues",
                table: "AtributeValues",
                columns: new[] { "idAtribute", "normalizedValue" });

            migrationBuilder.CreateIndex(
                name: "IX_AtributeValues_parentidAtribute_parentnormalizedValue",
                table: "AtributeValues",
                columns: new[] { "parentidAtribute", "parentnormalizedValue" });

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_AtributeValues_parentidAtribute_parentnormalizedValue",
                table: "AtributeValues",
                columns: new[] { "parentidAtribute", "parentnormalizedValue" },
                principalTable: "AtributeValues",
                principalColumns: new[] { "idAtribute", "normalizedValue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_AtributeValues_parentidAtribute_parentnormalizedValue",
                table: "AtributeValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtributeValues",
                table: "AtributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AtributeValues_parentidAtribute_parentnormalizedValue",
                table: "AtributeValues");

            migrationBuilder.DropColumn(
                name: "normalizedName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "normalizedValue",
                table: "AtributeValues");

            migrationBuilder.DropColumn(
                name: "parentnormalizedValue",
                table: "AtributeValues");

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "AtributeValues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parentvalue",
                table: "AtributeValues",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtributeValues",
                table: "AtributeValues",
                columns: new[] { "idAtribute", "value" });

            migrationBuilder.CreateIndex(
                name: "IX_AtributeValues_parentidAtribute_parentvalue",
                table: "AtributeValues",
                columns: new[] { "parentidAtribute", "parentvalue" });

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_AtributeValues_parentidAtribute_parentvalue",
                table: "AtributeValues",
                columns: new[] { "parentidAtribute", "parentvalue" },
                principalTable: "AtributeValues",
                principalColumns: new[] { "idAtribute", "value" });
        }
    }
}
