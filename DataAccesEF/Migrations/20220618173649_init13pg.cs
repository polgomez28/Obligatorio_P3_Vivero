using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init13pg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_FichaCuidados_FichaCuidadosId",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TipoPlantas_TipoPlantaId",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_FichaCuidadosId",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_TipoPlantaId",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "FichaCuidadosId",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "TipoPlantaId",
                table: "Plantas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Plantas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PlantaIdPlanta",
                table: "Fotos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_Id",
                table: "Plantas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_Id",
                table: "Plantas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_PlantaIdPlanta",
                table: "Fotos",
                column: "PlantaIdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotos_Plantas_PlantaIdPlanta",
                table: "Fotos",
                column: "PlantaIdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_FichaCuidados_Id",
                table: "Plantas",
                column: "Id",
                principalTable: "FichaCuidados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TipoPlantas_Id",
                table: "Plantas",
                column: "Id",
                principalTable: "TipoPlantas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotos_Plantas_PlantaIdPlanta",
                table: "Fotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_FichaCuidados_Id",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TipoPlantas_Id",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_Id",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_Id",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Fotos_PlantaIdPlanta",
                table: "Fotos");

            migrationBuilder.DropColumn(
                name: "PlantaIdPlanta",
                table: "Fotos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Plantas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FichaCuidadosId",
                table: "Plantas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoPlantaId",
                table: "Plantas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_FichaCuidadosId",
                table: "Plantas",
                column: "FichaCuidadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_TipoPlantaId",
                table: "Plantas",
                column: "TipoPlantaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_FichaCuidados_FichaCuidadosId",
                table: "Plantas",
                column: "FichaCuidadosId",
                principalTable: "FichaCuidados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TipoPlantas_TipoPlantaId",
                table: "Plantas",
                column: "TipoPlantaId",
                principalTable: "TipoPlantas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
