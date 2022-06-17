using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init4pg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidados_Plantas_PlantaIdPlanta",
                table: "FichaCuidados");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoPlantas_Plantas_PlantaIdPlanta",
                table: "TipoPlantas");

            migrationBuilder.DropIndex(
                name: "IX_TipoPlantas_PlantaIdPlanta",
                table: "TipoPlantas");

            migrationBuilder.DropIndex(
                name: "IX_FichaCuidados_PlantaIdPlanta",
                table: "FichaCuidados");

            migrationBuilder.DropColumn(
                name: "PlantaIdPlanta",
                table: "TipoPlantas");

            migrationBuilder.DropColumn(
                name: "PlantaIdPlanta",
                table: "FichaCuidados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantaIdPlanta",
                table: "TipoPlantas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantaIdPlanta",
                table: "FichaCuidados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPlantas_PlantaIdPlanta",
                table: "TipoPlantas",
                column: "PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidados_PlantaIdPlanta",
                table: "FichaCuidados",
                column: "PlantaIdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidados_Plantas_PlantaIdPlanta",
                table: "FichaCuidados",
                column: "PlantaIdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPlantas_Plantas_PlantaIdPlanta",
                table: "TipoPlantas",
                column: "PlantaIdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
