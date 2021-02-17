using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class Extend_ApplicationUser_UserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilizatori");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    Utilizator_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cont_activ = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Nume = table.Column<string>(nullable: true),
                    Parola = table.Column<string>(nullable: true),
                    Prenume = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Ultima_logare = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.Utilizator_Id);
                });
        }
    }
}
