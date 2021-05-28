using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsReviewsAngular.Migrations
{
    public partial class AdminInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Products_ProductidProduct",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_Atributes_AtributeidAtribute",
                table: "AtributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_AtributeValues_ParentidAtributeValue",
                table: "AtributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_Products_ProductidProduct",
                table: "AtributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleidArticle",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Producers_Countries_CountryidCountry",
                table: "Producers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_ProduceridProducer",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ArticleidArticle",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtributeValues",
                table: "AtributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AtributeValues_AtributeidAtribute",
                table: "AtributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AtributeValues_ParentidAtributeValue",
                table: "AtributeValues");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0b09882-cbbb-4082-a4cb-bbe294aed376");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f57ce44a-c3fc-4f4d-a38e-3b59f2fe466d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3f16ccba-1364-4453-96bc-f4c6776ae662", "e30df65e-1207-4720-9359-d5ce2da375cb" });

            migrationBuilder.DropColumn(
                name: "ArticleidArticle",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "idAtributeValue",
                table: "AtributeValues");

            migrationBuilder.DropColumn(
                name: "AtributeidAtribute",
                table: "AtributeValues");

            migrationBuilder.RenameColumn(
                name: "ParentidAtributeValue",
                table: "AtributeValues",
                newName: "ParentidAtribute");

            migrationBuilder.AddColumn<float>(
                name: "rating",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "AtributeValues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parentvalue",
                table: "AtributeValues",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtributeValues",
                table: "AtributeValues",
                columns: new[] { "idAtribute", "value" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c5a7c19-8b05-42c4-b8fc-740f50dba3db", "7a55beaa-eb83-4dd4-b41a-2ad1049c5dcd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff01658f-b94d-4c59-b9f7-76c65f4e2fe4", "0021c2e5-4c13-4763-85e7-af0af899a647", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_idArticle",
                table: "Comments",
                column: "idArticle");

            migrationBuilder.CreateIndex(
                name: "IX_AtributeValues_ParentidAtribute_Parentvalue",
                table: "AtributeValues",
                columns: new[] { "ParentidAtribute", "Parentvalue" });

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Products_ProductidProduct",
                table: "Articles",
                column: "ProductidProduct",
                principalTable: "Products",
                principalColumn: "idProduct",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_Atributes_idAtribute",
                table: "AtributeValues",
                column: "idAtribute",
                principalTable: "Atributes",
                principalColumn: "idAtribute",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_AtributeValues_ParentidAtribute_Parentvalue",
                table: "AtributeValues",
                columns: new[] { "ParentidAtribute", "Parentvalue" },
                principalTable: "AtributeValues",
                principalColumns: new[] { "idAtribute", "value" });

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_Products_ProductidProduct",
                table: "AtributeValues",
                column: "ProductidProduct",
                principalTable: "Products",
                principalColumn: "idProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_idArticle",
                table: "Comments",
                column: "idArticle",
                principalTable: "Articles",
                principalColumn: "idArticle");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producers_Countries_CountryidCountry",
                table: "Producers",
                column: "CountryidCountry",
                principalTable: "Countries",
                principalColumn: "idCountry",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_ProduceridProducer",
                table: "Products",
                column: "ProduceridProducer",
                principalTable: "Producers",
                principalColumn: "idProducer",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Products_ProductidProduct",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_Atributes_idAtribute",
                table: "AtributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_AtributeValues_ParentidAtribute_Parentvalue",
                table: "AtributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_AtributeValues_Products_ProductidProduct",
                table: "AtributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_idArticle",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Producers_Countries_CountryidCountry",
                table: "Producers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_ProduceridProducer",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Comments_idArticle",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtributeValues",
                table: "AtributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AtributeValues_ParentidAtribute_Parentvalue",
                table: "AtributeValues");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c5a7c19-8b05-42c4-b8fc-740f50dba3db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff01658f-b94d-4c59-b9f7-76c65f4e2fe4");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Parentvalue",
                table: "AtributeValues");

            migrationBuilder.RenameColumn(
                name: "ParentidAtribute",
                table: "AtributeValues",
                newName: "ParentidAtributeValue");

            migrationBuilder.AddColumn<int>(
                name: "ArticleidArticle",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "AtributeValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "idAtributeValue",
                table: "AtributeValues",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AtributeidAtribute",
                table: "AtributeValues",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtributeValues",
                table: "AtributeValues",
                column: "idAtributeValue");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0b09882-cbbb-4082-a4cb-bbe294aed376", "aeabec33-03c0-4eb8-b212-798b1ef77efa", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f57ce44a-c3fc-4f4d-a38e-3b59f2fe466d", "b4273398-0b8b-49c5-ba99-5c054206580b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3f16ccba-1364-4453-96bc-f4c6776ae662", "e30df65e-1207-4720-9359-d5ce2da375cb" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleidArticle",
                table: "Comments",
                column: "ArticleidArticle");

            migrationBuilder.CreateIndex(
                name: "IX_AtributeValues_AtributeidAtribute",
                table: "AtributeValues",
                column: "AtributeidAtribute");

            migrationBuilder.CreateIndex(
                name: "IX_AtributeValues_ParentidAtributeValue",
                table: "AtributeValues",
                column: "ParentidAtributeValue");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Products_ProductidProduct",
                table: "Articles",
                column: "ProductidProduct",
                principalTable: "Products",
                principalColumn: "idProduct",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_Atributes_AtributeidAtribute",
                table: "AtributeValues",
                column: "AtributeidAtribute",
                principalTable: "Atributes",
                principalColumn: "idAtribute",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_AtributeValues_ParentidAtributeValue",
                table: "AtributeValues",
                column: "ParentidAtributeValue",
                principalTable: "AtributeValues",
                principalColumn: "idAtributeValue");

            migrationBuilder.AddForeignKey(
                name: "FK_AtributeValues_Products_ProductidProduct",
                table: "AtributeValues",
                column: "ProductidProduct",
                principalTable: "Products",
                principalColumn: "idProduct",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleidArticle",
                table: "Comments",
                column: "ArticleidArticle",
                principalTable: "Articles",
                principalColumn: "idArticle",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producers_Countries_CountryidCountry",
                table: "Producers",
                column: "CountryidCountry",
                principalTable: "Countries",
                principalColumn: "idCountry",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_ProduceridProducer",
                table: "Products",
                column: "ProduceridProducer",
                principalTable: "Producers",
                principalColumn: "idProducer",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
