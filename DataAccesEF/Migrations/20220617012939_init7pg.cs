using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init7pg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Compras_ComprasIdCompra",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_ComprasIdCompra",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "ComprasIdCompra",
                table: "Plantas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComprasIdCompra",
                table: "Plantas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_ComprasIdCompra",
                table: "Plantas",
                column: "ComprasIdCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Compras_ComprasIdCompra",
                table: "Plantas",
                column: "ComprasIdCompra",
                principalTable: "Compras",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
