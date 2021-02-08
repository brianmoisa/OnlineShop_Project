using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class ProduseAndPromotii_poza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Procentaj",
                table: "Promotii_Produse",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "Pret",
                table: "Produse",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "Cantitate",
                table: "Produse",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdaugare",
                table: "Produse",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Poza",
                table: "Produse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAdaugare",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "Poza",
                table: "Produse");

            migrationBuilder.AlterColumn<int>(
                name: "Procentaj",
                table: "Promotii_Produse",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Pret",
                table: "Produse",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Cantitate",
                table: "Produse",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);
        }
    }
}
