using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiraApi.Migrations
{
    public partial class InitialDtbbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    UserModelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<long>(type: "INTEGER", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.UserModelId);
                });

            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    FolhaPagamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValorHora = table.Column<double>(type: "REAL", nullable: false),
                    QuantidadeHorar = table.Column<int>(type: "INTEGER", nullable: false),
                    SalarioBruto = table.Column<double>(type: "REAL", nullable: false),
                    ImpostoDeRenda = table.Column<double>(type: "REAL", nullable: false),
                    ImpostoInss = table.Column<double>(type: "REAL", nullable: false),
                    ImpostoFgts = table.Column<double>(type: "REAL", nullable: false),
                    SalarioLiquido = table.Column<double>(type: "REAL", nullable: false),
                    UserModelID = table.Column<int>(type: "INTEGER", nullable: false),
                    MesPagamento = table.Column<int>(type: "INTEGER", nullable: false),
                    AnoPagamento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.FolhaPagamentoId);
                    table.ForeignKey(
                        name: "FK_Folhas_UserModels_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "UserModels",
                        principalColumn: "UserModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_UserModelID",
                table: "Folhas",
                column: "UserModelID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}
