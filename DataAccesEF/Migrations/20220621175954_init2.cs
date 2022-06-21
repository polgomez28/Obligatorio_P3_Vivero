using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComprasId",
                table: "ItemCompras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_ComprasId",
                table: "ItemCompras",
                column: "ComprasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompras_Compras_ComprasId",
                table: "ItemCompras",
                column: "ComprasId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompras_Compras_ComprasId",
                table: "ItemCompras");

            migrationBuilder.DropIndex(
                name: "IX_ItemCompras_ComprasId",
                table: "ItemCompras");

            migrationBuilder.DropColumn(
                name: "ComprasId",
                table: "ItemCompras");
        }
    }
}
