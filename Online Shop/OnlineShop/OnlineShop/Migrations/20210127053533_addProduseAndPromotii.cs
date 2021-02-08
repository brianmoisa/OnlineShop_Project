using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class addProduseAndPromotii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id_Produs = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true),
                    Descriere = table.Column<string>(nullable: true),
                    Pret = table.Column<float>(nullable: false),
                    Cantitate = table.Column<float>(nullable: false),
                    Nume_subcateg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id_Produs);
                    table.ForeignKey(
                        name: "FK_Produse_Subcategorii_Nume_subcateg",
                        column: x => x.Nume_subcateg,
                        principalTable: "Subcategorii",
                        principalColumn: "Nume_subcateg",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promotie",
                columns: table => new
                {
                    Id_promotie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data_inceput = table.Column<DateTime>(nullable: false),
                    Data_sfarsit = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotie", x => x.Id_promotie);
                });

            migrationBuilder.CreateTable(
                name: "Promotie_Produs",
                columns: table => new
                {
                    Id_Produs = table.Column<int>(nullable: false),
                    Id_promotie = table.Column<int>(nullable: false),
                    Procentaj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotie_Produs", x => new { x.Id_Produs, x.Id_promotie });
                    table.ForeignKey(
                        name: "FK_Promotie_Produs_Produse_Id_Produs",
                        column: x => x.Id_Produs,
                        principalTable: "Produse",
                        principalColumn: "Id_Produs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promotie_Produs_Promotie_Id_promotie",
                        column: x => x.Id_promotie,
                        principalTable: "Promotie",
                        principalColumn: "Id_promotie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produse_Nume_subcateg",
                table: "Produse",
                column: "Nume_subcateg");

            migrationBuilder.CreateIndex(
                name: "IX_Promotie_Produs_Id_promotie",
                table: "Promotie_Produs",
                column: "Id_promotie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotie_Produs");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Promotie");
        }
    }
}
