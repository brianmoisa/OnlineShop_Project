using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class addCategAndSubcateg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorii",
                columns: table => new
                {
                    Nume_categorie = table.Column<string>(nullable: false),
                    Descriere = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorii", x => x.Nume_categorie);
                });

            migrationBuilder.CreateTable(
                name: "Subcategorii",
                columns: table => new
                {
                    Nume_subcateg = table.Column<string>(nullable: false),
                    Descriere = table.Column<string>(nullable: true),
                    Nume_categorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategorii", x => x.Nume_subcateg);
                    table.ForeignKey(
                        name: "FK_Subcategorii_Categorii_Nume_categorie",
                        column: x => x.Nume_categorie,
                        principalTable: "Categorii",
                        principalColumn: "Nume_categorie",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subcategorii_Nume_categorie",
                table: "Subcategorii",
                column: "Nume_categorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subcategorii");

            migrationBuilder.DropTable(
                name: "Categorii");
        }
    }
}
