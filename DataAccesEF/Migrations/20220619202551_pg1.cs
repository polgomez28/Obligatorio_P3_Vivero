using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesEF.Migrations
{
    public partial class pg1 : Migration
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
                name: "TipoIluminacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIluminacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlantas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlantas", x => x.Id);
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
                name: "FichaCuidados",
                columns: table => new
                {
                    IdFichaCuidados = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Riego = table.Column<string>(nullable: true),
                    IdTipoIluminacion = table.Column<int>(nullable: false),
                    Temperatura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaCuidados", x => x.IdFichaCuidados);
                    table.ForeignKey(
                        name: "FK_FichaCuidados_TipoIluminacion_IdTipoIluminacion",
                        column: x => x.IdTipoIluminacion,
                        principalTable: "TipoIluminacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    IdPlanta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: false),
                    IdTipoPlanta = table.Column<int>(nullable: false),
                    IdFichaCuidados = table.Column<int>(nullable: true),
                    NombresVulgares = table.Column<string>(nullable: false),
                    Ambiente = table.Column<string>(nullable: false),
                    Altura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.IdPlanta);
                    table.ForeignKey(
                        name: "FK_Plantas_FichaCuidados_IdFichaCuidados",
                        column: x => x.IdFichaCuidados,
                        principalTable: "FichaCuidados",
                        principalColumn: "IdFichaCuidados",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plantas_TipoPlantas_IdTipoPlanta",
                        column: x => x.IdTipoPlanta,
                        principalTable: "TipoPlantas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    CostoTotal = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CostoFlete = table.Column<double>(nullable: true),
                    IdPlanta = table.Column<int>(nullable: true),
                    EsDelSur = table.Column<bool>(nullable: true),
                    TasaDescuento = table.Column<int>(nullable: true),
                    Importadas_IdPlanta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Plantas_IdPlanta",
                        column: x => x.IdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compras_Plantas_Importadas_IdPlanta",
                        column: x => x.Importadas_IdPlanta,
                        principalTable: "Plantas",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Compras_IdPlanta",
                table: "Compras",
                column: "IdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Importadas_IdPlanta",
                table: "Compras",
                column: "Importadas_IdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidados_IdTipoIluminacion",
                table: "FichaCuidados",
                column: "IdTipoIluminacion");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_PlantaIdPlanta",
                table: "Fotos",
                column: "PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_ComprasIdCompra",
                table: "ItemCompras",
                column: "ComprasIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_PlantaIdPlanta",
                table: "ItemCompras",
                column: "PlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_IdFichaCuidados",
                table: "Plantas",
                column: "IdFichaCuidados");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_IdTipoPlanta",
                table: "Plantas",
                column: "IdTipoPlanta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "ItemCompras");

            migrationBuilder.DropTable(
                name: "ParamSistema");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Plantas");

            migrationBuilder.DropTable(
                name: "FichaCuidados");

            migrationBuilder.DropTable(
                name: "TipoPlantas");

            migrationBuilder.DropTable(
                name: "TipoIluminacion");
        }
    }
}
