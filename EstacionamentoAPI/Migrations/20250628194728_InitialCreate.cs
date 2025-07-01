using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionamentoAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuracao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeMaximaVagas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoVeiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VeiculosEstacionados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculosEstacionados", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuracao");

            migrationBuilder.DropTable(
                name: "HistoricoVeiculos");

            migrationBuilder.DropTable(
                name: "VeiculosEstacionados");
        }
    }
}
