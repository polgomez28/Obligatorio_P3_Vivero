using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init5pg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidados_TipoIluminacions_TipoIluminacionIdIluminacion",
                table: "FichaCuidados");

            migrationBuilder.DropIndex(
                name: "IX_FichaCuidados_TipoIluminacionIdIluminacion",
                table: "FichaCuidados");

            migrationBuilder.DropColumn(
                name: "TipoIluminacionIdIluminacion",
                table: "FichaCuidados");

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidados_IdTipoIluminacion",
                table: "FichaCuidados",
                column: "IdTipoIluminacion");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidados_TipoIluminacions_IdTipoIluminacion",
                table: "FichaCuidados",
                column: "IdTipoIluminacion",
                principalTable: "TipoIluminacions",
                principalColumn: "IdIluminacion",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidados_TipoIluminacions_IdTipoIluminacion",
                table: "FichaCuidados");

            migrationBuilder.DropIndex(
                name: "IX_FichaCuidados_IdTipoIluminacion",
                table: "FichaCuidados");

            migrationBuilder.AddColumn<int>(
                name: "TipoIluminacionIdIluminacion",
                table: "FichaCuidados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidados_TipoIluminacionIdIluminacion",
                table: "FichaCuidados",
                column: "TipoIluminacionIdIluminacion");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidados_TipoIluminacions_TipoIluminacionIdIluminacion",
                table: "FichaCuidados",
                column: "TipoIluminacionIdIluminacion",
                principalTable: "TipoIluminacions",
                principalColumn: "IdIluminacion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
