using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class initpg10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidados_TipoIluminacions_IdTipoIluminacion",
                table: "FichaCuidados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoIluminacions",
                table: "TipoIluminacions");

            migrationBuilder.RenameTable(
                name: "TipoIluminacions",
                newName: "TipoIluminacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoIluminacion",
                table: "TipoIluminacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidados_TipoIluminacion_IdTipoIluminacion",
                table: "FichaCuidados",
                column: "IdTipoIluminacion",
                principalTable: "TipoIluminacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidados_TipoIluminacion_IdTipoIluminacion",
                table: "FichaCuidados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoIluminacion",
                table: "TipoIluminacion");

            migrationBuilder.RenameTable(
                name: "TipoIluminacion",
                newName: "TipoIluminacions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoIluminacions",
                table: "TipoIluminacions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidados_TipoIluminacions_IdTipoIluminacion",
                table: "FichaCuidados",
                column: "IdTipoIluminacion",
                principalTable: "TipoIluminacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
