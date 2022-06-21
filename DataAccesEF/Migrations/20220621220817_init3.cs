using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantaIdPlanta",
                table: "ItemCompras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_PlantaIdPlanta",
                table: "ItemCompras",
                column: "PlantaIdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompras_Plantas_PlantaIdPlanta",
                table: "ItemCompras",
                column: "PlantaIdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompras_Plantas_PlantaIdPlanta",
                table: "ItemCompras");

            migrationBuilder.DropIndex(
                name: "IX_ItemCompras_PlantaIdPlanta",
                table: "ItemCompras");

            migrationBuilder.DropColumn(
                name: "PlantaIdPlanta",
                table: "ItemCompras");
        }
    }
}
