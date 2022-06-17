using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init3pg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoNombre",
                table: "TipoPlantas",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "TipoDesc",
                table: "TipoPlantas",
                newName: "Desc");

            migrationBuilder.RenameColumn(
                name: "IdTipoPlanta",
                table: "TipoPlantas",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "TipoPlantas",
                newName: "TipoNombre");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "TipoPlantas",
                newName: "TipoDesc");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoPlantas",
                newName: "IdTipoPlanta");
        }
    }
}
