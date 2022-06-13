using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init2pg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_ItemPlantas_ItemPlantasIdItemPlanta",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ItemPlantasIdItemPlanta",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "IdItemPlanta",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "ItemPlantasIdItemPlanta",
                table: "Compras");

            migrationBuilder.CreateTable(
                name: "ItemCompras",
                columns: table => new
                {
                    IdPlanta = table.Column<int>(nullable: false),
                    IdCompra = table.Column<int>(nullable: false),
                    PlantaIdPlanta = table.Column<int>(nullable: true),
                    ComprasIdCompra = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCompras", x => new { x.IdCompra, x.IdPlanta });
                    table.ForeignKey(
                        name: "FK_ItemCompras_Compras_ComprasIdCompra",
                        column: x => x.ComprasIdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCompras_Plantas_PlantaIdPlanta",
                        column: x => x.PlantaIdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_ComprasIdCompra",
                table: "ItemCompras",
                column: "ComprasIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_PlantaIdPlanta",
                table: "ItemCompras",
                column: "PlantaIdPlanta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCompras");

            migrationBuilder.AddColumn<int>(
                name: "IdItemPlanta",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemPlantasIdItemPlanta",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ItemPlantasIdItemPlanta",
                table: "Compras",
                column: "ItemPlantasIdItemPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_ItemPlantas_ItemPlantasIdItemPlanta",
                table: "Compras",
                column: "ItemPlantasIdItemPlanta",
                principalTable: "ItemPlantas",
                principalColumn: "IdItemPlanta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
