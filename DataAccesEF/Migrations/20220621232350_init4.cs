using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompras_Compras_ComprasId",
                table: "ItemCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompras_Plantas_PlantaIdPlanta",
                table: "ItemCompras");

            migrationBuilder.DropIndex(
                name: "IX_ItemCompras_ComprasId",
                table: "ItemCompras");

            migrationBuilder.DropIndex(
                name: "IX_ItemCompras_PlantaIdPlanta",
                table: "ItemCompras");

            migrationBuilder.DropColumn(
                name: "ComprasId",
                table: "ItemCompras");

            migrationBuilder.DropColumn(
                name: "PlantaIdPlanta",
                table: "ItemCompras");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_IdPlanta",
                table: "ItemCompras",
                column: "IdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompras_Compras_IdCompra",
                table: "ItemCompras",
                column: "IdCompra",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompras_Plantas_IdPlanta",
                table: "ItemCompras",
                column: "IdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompras_Compras_IdCompra",
                table: "ItemCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompras_Plantas_IdPlanta",
                table: "ItemCompras");

            migrationBuilder.DropIndex(
                name: "IX_ItemCompras_IdPlanta",
                table: "ItemCompras");

            migrationBuilder.AddColumn<int>(
                name: "ComprasId",
                table: "ItemCompras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantaIdPlanta",
                table: "ItemCompras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_ComprasId",
                table: "ItemCompras",
                column: "ComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_PlantaIdPlanta",
                table: "ItemCompras",
                column: "PlantaIdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompras_Compras_ComprasId",
                table: "ItemCompras",
                column: "ComprasId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompras_Plantas_PlantaIdPlanta",
                table: "ItemCompras",
                column: "PlantaIdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
