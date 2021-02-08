using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class addProduseAndPromotii2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotie_Produs_Produse_Id_Produs",
                table: "Promotie_Produs");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotie_Produs_Promotie_Id_promotie",
                table: "Promotie_Produs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotie_Produs",
                table: "Promotie_Produs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotie",
                table: "Promotie");

            migrationBuilder.RenameTable(
                name: "Promotie_Produs",
                newName: "Promotii_Produse");

            migrationBuilder.RenameTable(
                name: "Promotie",
                newName: "Promotii");

            migrationBuilder.RenameIndex(
                name: "IX_Promotie_Produs_Id_promotie",
                table: "Promotii_Produse",
                newName: "IX_Promotii_Produse_Id_promotie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotii_Produse",
                table: "Promotii_Produse",
                columns: new[] { "Id_Produs", "Id_promotie" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotii",
                table: "Promotii",
                column: "Id_promotie");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotii_Produse_Produse_Id_Produs",
                table: "Promotii_Produse",
                column: "Id_Produs",
                principalTable: "Produse",
                principalColumn: "Id_Produs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotii_Produse_Promotii_Id_promotie",
                table: "Promotii_Produse",
                column: "Id_promotie",
                principalTable: "Promotii",
                principalColumn: "Id_promotie",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotii_Produse_Produse_Id_Produs",
                table: "Promotii_Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotii_Produse_Promotii_Id_promotie",
                table: "Promotii_Produse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotii_Produse",
                table: "Promotii_Produse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotii",
                table: "Promotii");

            migrationBuilder.RenameTable(
                name: "Promotii_Produse",
                newName: "Promotie_Produs");

            migrationBuilder.RenameTable(
                name: "Promotii",
                newName: "Promotie");

            migrationBuilder.RenameIndex(
                name: "IX_Promotii_Produse_Id_promotie",
                table: "Promotie_Produs",
                newName: "IX_Promotie_Produs_Id_promotie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotie_Produs",
                table: "Promotie_Produs",
                columns: new[] { "Id_Produs", "Id_promotie" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotie",
                table: "Promotie",
                column: "Id_promotie");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotie_Produs_Produse_Id_Produs",
                table: "Promotie_Produs",
                column: "Id_Produs",
                principalTable: "Produse",
                principalColumn: "Id_Produs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotie_Produs_Promotie_Id_promotie",
                table: "Promotie_Produs",
                column: "Id_promotie",
                principalTable: "Promotie",
                principalColumn: "Id_promotie",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
