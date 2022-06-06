using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParamSistema",
                columns: table => new
                {
                    IdParam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    ValorMin = table.Column<int>(nullable: false),
                    ValorMax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamSistema", x => x.IdParam);
                });

            migrationBuilder.CreateTable(
                name: "TipoIluminacions",
                columns: table => new
                {
                    IdIluminacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionTipoIlum = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIluminacions", x => x.IdIluminacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "ItemPlantas",
                columns: table => new
                {
                    IdItemPlanta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantaCompradaIdPlanta = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<double>(nullable: false),
                    IdPlanta = table.Column<int>(nullable: false),
                    IdCompra = table.Column<int>(nullable: false),
                    ComprasIdCompra = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPlantas", x => x.IdItemPlanta);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    IdPlanta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: false),
                    TipoPlantaIdTipoPlanta = table.Column<int>(nullable: false),
                    FichaCuidadosIdFichaCuidados = table.Column<int>(nullable: true),
                    NombresVulgares = table.Column<string>(nullable: true),
                    Ambiente = table.Column<string>(nullable: false),
                    Altura = table.Column<int>(nullable: false),
                    IdTipoPlanta = table.Column<int>(nullable: false),
                    IdFichaCuidados = table.Column<int>(nullable: false),
                    ComprasIdCompra = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.IdPlanta);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    CostoTotal = table.Column<double>(nullable: false),
                    IdItemPlanta = table.Column<int>(nullable: false),
                    ItemPlantasIdItemPlanta = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CostoFlete = table.Column<double>(nullable: true),
                    IdPlanta = table.Column<int>(nullable: true),
                    PlantaIdPlanta = table.Column<int>(nullable: true),
                    EsDelSur = table.Column<bool>(nullable: true),
                    TasaDescuento = table.Column<int>(nullable: true),
                    Importadas_IdPlanta = table.Column<int>(nullable: true),
                    Importadas_PlantaIdPlanta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_ItemPlantas_ItemPlantasIdItemPlanta",
                        column: x => x.ItemPlantasIdItemPlanta,
                        principalTable: "ItemPlantas",
                        principalColumn: "IdItemPlanta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compras_Plantas_PlantaIdPlanta",
                        column: x => x.PlantaIdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compras_Plantas_Importadas_PlantaIdPlanta",
                        column: x => x.Importadas_PlantaIdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichaCuidados",
                columns: table => new
                {
                    IdFichaCuidados = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Riego = table.Column<string>(nullable: true),
                    TipoIluminacionIdIluminacion = table.Column<int>(nullable: false),
                    Temperatura = table.Column<int>(nullable: false),
                    IdTipoIluminacion = table.Column<int>(nullable: false),
                    PlantaIdPlanta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaCuidados", x => x.IdFichaCuidados);
                    table.ForeignKey(
                        name: "FK_FichaCuidados_Plantas_PlantaIdPlanta",
                        column: x => x.PlantaIdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichaCuidados_TipoIluminacions_TipoIluminacionIdIluminacion",
                        column: x => x.TipoIluminacionIdIluminacion,
                        principalTable: "TipoIluminacions",
                        principalColumn: "IdIluminacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    IdFoto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Imagen = table.Column<byte[]>(nullable: true),
                    PlantaIdPlanta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.IdFoto);
                    table.ForeignKey(
                        name: "FK_Fotos_Plantas_PlantaIdPlanta",
                        column: x => x.PlantaIdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlantas",
                columns: table => new
                {
                    IdTipoPlanta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNombre = table.Column<string>(nullable: false),
                    TipoDesc = table.Column<string>(nullable: false),
                    PlantaIdPlanta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlantas", x => x.IdTipoPlanta);
                    table.ForeignKey(
                        name: "FK_TipoPlantas_Plantas_PlantaIdPlanta",
                        column: x => x.PlantaIdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ItemPlantasIdItemPlanta",
                table: "Compras",
                column: "ItemPlantasIdItemPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_PlantaIdPlanta",
                table: "Compras",
                column: "PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Importadas_PlantaIdPlanta",
                table: "Compras",
                column: "Importadas_PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidados_PlantaIdPlanta",
                table: "FichaCuidados",
                column: "PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidados_TipoIluminacionIdIluminacion",
                table: "FichaCuidados",
                column: "TipoIluminacionIdIluminacion");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_PlantaIdPlanta",
                table: "Fotos",
                column: "PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlantas_ComprasIdCompra",
                table: "ItemPlantas",
                column: "ComprasIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlantas_PlantaCompradaIdPlanta",
                table: "ItemPlantas",
                column: "PlantaCompradaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_ComprasIdCompra",
                table: "Plantas",
                column: "ComprasIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_FichaCuidadosIdFichaCuidados",
                table: "Plantas",
                column: "FichaCuidadosIdFichaCuidados");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_TipoPlantaIdTipoPlanta",
                table: "Plantas",
                column: "TipoPlantaIdTipoPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPlantas_PlantaIdPlanta",
                table: "TipoPlantas",
                column: "PlantaIdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlantas_Plantas_PlantaCompradaIdPlanta",
                table: "ItemPlantas",
                column: "PlantaCompradaIdPlanta",
                principalTable: "Plantas",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlantas_Compras_ComprasIdCompra",
                table: "ItemPlantas",
                column: "ComprasIdCompra",
                principalTable: "Compras",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Compras_ComprasIdCompra",
                table: "Plantas",
                column: "ComprasIdCompra",
                principalTable: "Compras",
                principalColumn: "IdCompra",
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
                principalColumn: "IdTipoPlanta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_ItemPlantas_ItemPlantasIdItemPlanta",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Plantas_PlantaIdPlanta",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Plantas_Importadas_PlantaIdPlanta",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidados_Plantas_PlantaIdPlanta",
                table: "FichaCuidados");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoPlantas_Plantas_PlantaIdPlanta",
                table: "TipoPlantas");

            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "ParamSistema");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ItemPlantas");

            migrationBuilder.DropTable(
                name: "Plantas");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "FichaCuidados");

            migrationBuilder.DropTable(
                name: "TipoPlantas");

            migrationBuilder.DropTable(
                name: "TipoIluminacions");
        }
    }
}
