using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CostoTotal",
                table: "Compras",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "TasaIVA",
                table: "Compras",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TasaIVA",
                table: "Compras");

            migrationBuilder.AlterColumn<double>(
                name: "CostoTotal",
                table: "Compras",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
