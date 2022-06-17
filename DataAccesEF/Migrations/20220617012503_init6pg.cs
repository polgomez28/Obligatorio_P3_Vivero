using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init6pg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Plantas_PlantaIdPlanta",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Plantas_Importadas_PlantaIdPlanta",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_FichaCuidados_FichaCuidadosIdFichaCuidados",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TipoPlantas_TipoPlantaIdTipoPlanta",
                table: "Plantas");

            migrationBuilder.DropTable(
                name: "ItemPlantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_FichaCuidadosIdFichaCuidados",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_TipoPlantaIdTipoPlanta",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Compras_PlantaIdPlanta",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_Importadas_PlantaIdPlanta",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "FichaCuidadosIdFichaCuidados",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "TipoPlantaIdTipoPlanta",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "PlantaIdPlanta",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Importadas_PlantaIdPlanta",
                table: "Compras");

            migrationBuilder.AlterColumn<int>(
                name: "IdFichaCuidados",
                table: "Plantas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_IdFichaCuidados",
                table: "Plantas",
                column: "IdFichaCuidados");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_IdTipoPlanta",
                table: "Plantas",
                column: "IdTipoPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdPlanta",
                table: "Compras",
                column: "IdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Importadas_IdPlanta",
                table: "Compras",
                column: "Importadas_IdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Plantas_IdPlanta",
                table: "Compras",
                column: "IdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Plantas_Importadas_IdPlanta",
                table: "Compras",
                column: "Importadas_IdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_FichaCuidados_IdFichaCuidados",
                table: "Plantas",
                column: "IdFichaCuidados",
                principalTable: "FichaCuidados",
                principalColumn: "IdFichaCuidados",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TipoPlantas_IdTipoPlanta",
                table: "Plantas",
                column: "IdTipoPlanta",
                principalTable: "TipoPlantas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Plantas_IdPlanta",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Plantas_Importadas_IdPlanta",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_FichaCuidados_IdFichaCuidados",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TipoPlantas_IdTipoPlanta",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_IdFichaCuidados",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_IdTipoPlanta",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdPlanta",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_Importadas_IdPlanta",
                table: "Compras");

            migrationBuilder.AlterColumn<int>(
                name: "IdFichaCuidados",
                table: "Plantas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FichaCuidadosIdFichaCuidados",
                table: "Plantas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoPlantaIdTipoPlanta",
                table: "Plantas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlantaIdPlanta",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Importadas_PlantaIdPlanta",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemPlantas",
                columns: table => new
                {
                    IdItemPlanta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ComprasIdCompra = table.Column<int>(type: "int", nullable: true),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdPlanta = table.Column<int>(type: "int", nullable: false),
                    PlantaCompradaIdPlanta = table.Column<int>(type: "int", nullable: true),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPlantas", x => x.IdItemPlanta);
                    table.ForeignKey(
                        name: "FK_ItemPlantas_Compras_ComprasIdCompra",
                        column: x => x.ComprasIdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPlantas_Plantas_PlantaCompradaIdPlanta",
                        column: x => x.PlantaCompradaIdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_FichaCuidadosIdFichaCuidados",
                table: "Plantas",
                column: "FichaCuidadosIdFichaCuidados");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_TipoPlantaIdTipoPlanta",
                table: "Plantas",
                column: "TipoPlantaIdTipoPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_PlantaIdPlanta",
                table: "Compras",
                column: "PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Importadas_PlantaIdPlanta",
                table: "Compras",
                column: "Importadas_PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlantas_ComprasIdCompra",
                table: "ItemPlantas",
                column: "ComprasIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlantas_PlantaCompradaIdPlanta",
                table: "ItemPlantas",
                column: "PlantaCompradaIdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Plantas_PlantaIdPlanta",
                table: "Compras",
                column: "PlantaIdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Plantas_Importadas_PlantaIdPlanta",
                table: "Compras",
                column: "Importadas_PlantaIdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_FichaCuidados_FichaCuidadosIdFichaCuidados",
                table: "Plantas",
                column: "FichaCuidadosIdFichaCuidados",
                principalTable: "FichaCuidados",
                principalColumn: "IdFichaCuidados",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TipoPlantas_TipoPlantaIdTipoPlanta",
                table: "Plantas",
                column: "TipoPlantaIdTipoPlanta",
                principalTable: "TipoPlantas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
