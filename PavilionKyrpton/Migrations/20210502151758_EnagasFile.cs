using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PavilionKyrpton.Migrations
{
    public partial class EnagasFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnagasFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileId = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoContrato = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoAdenda = table.Column<string>(type: "TEXT", nullable: true),
                    FechaFormalizacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Origen = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroSolicitud = table.Column<string>(type: "TEXT", nullable: true),
                    Comercializador = table.Column<string>(type: "TEXT", nullable: true),
                    Servicio = table.Column<string>(type: "TEXT", nullable: true),
                    MateriaPrima = table.Column<string>(type: "TEXT", nullable: true),
                    NaturalezaCapacidad = table.Column<string>(type: "TEXT", nullable: true),
                    Coordinacion = table.Column<string>(type: "TEXT", nullable: true),
                    SentidoFlujo = table.Column<string>(type: "TEXT", nullable: true),
                    Operador = table.Column<string>(type: "TEXT", nullable: true),
                    TipoInfrastructura = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDuracion = table.Column<string>(type: "TEXT", nullable: true),
                    InicioContracto = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinContracto = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duracion_horas = table.Column<int>(type: "INTEGER", nullable: false),
                    QTotalContratada_Volume = table.Column<decimal>(type: "TEXT", nullable: false),
                    QTotalContratada_Units = table.Column<string>(type: "TEXT", nullable: true),
                    QFirmeContratada_Volume = table.Column<decimal>(type: "TEXT", nullable: false),
                    QFirmeContratada_Units = table.Column<string>(type: "TEXT", nullable: true),
                    QIntContratada_Volume = table.Column<decimal>(type: "TEXT", nullable: false),
                    QIntContratada_Units = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TipoPeaje = table.Column<string>(type: "TEXT", nullable: true),
                    ContratoOrigen = table.Column<string>(type: "TEXT", nullable: true),
                    Transaccion = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoSubasta = table.Column<string>(type: "TEXT", nullable: true),
                    IdOfertaTransaccion = table.Column<string>(type: "TEXT", nullable: true),
                    Prima_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Prima_Units = table.Column<string>(type: "TEXT", nullable: true),
                    Precio_Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Precio_Units = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnagasFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnagasFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnagasFiles_FileId",
                table: "EnagasFiles",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnagasFiles");
        }
    }
}
