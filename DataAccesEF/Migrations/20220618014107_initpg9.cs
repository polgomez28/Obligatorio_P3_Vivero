using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class initpg9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescripcionTipoIlum",
                table: "TipoIluminacions",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "IdIluminacion",
                table: "TipoIluminacions",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "TipoIluminacions",
                newName: "DescripcionTipoIlum");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoIluminacions",
                newName: "IdIluminacion");
        }
    }
}
