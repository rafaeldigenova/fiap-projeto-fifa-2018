using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fiap.ProjetoFifa2018.Persistencia.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 15, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataDaPartida = table.Column<DateTime>(nullable: false),
                    IdDoTimeMandante = table.Column<int>(nullable: false),
                    IdDoTimeVencedor = table.Column<int>(nullable: false),
                    IdDoTimeVisitante = table.Column<int>(nullable: false),
                    NomeDoTimeMandante = table.Column<string>(nullable: false),
                    NomeDoTimeVisitante = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playoffs",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 15, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDaPartidaDeIda = table.Column<int>(nullable: false),
                    IdDaPartidaDeVolta = table.Column<int>(nullable: false),
                    IdDoTimeVencedor = table.Column<int>(nullable: false),
                    Nivel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playoffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 15, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Escudo = table.Column<string>(maxLength: 150, nullable: false),
                    NomeDoTime = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Torneios",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 15, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataDeInicioDoTorneio = table.Column<DateTime>(nullable: false),
                    QuantidadeDeGrupos = table.Column<int>(nullable: false),
                    QuantidadeDeTimes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GolsDasPartidas",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 15, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDoJogadorQueMarcou = table.Column<int>(nullable: false),
                    IdDoTimeQueMarcou = table.Column<int>(nullable: false),
                    NomeDoJogadorQueMarcou = table.Column<string>(nullable: false),
                    PartidaId = table.Column<int>(nullable: false),
                    TempoDoGolEmMinutos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolsDasPartidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GolsDasPartidas_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 15, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    NumeroDaCamisa = table.Column<int>(maxLength: 2, nullable: false),
                    Posicao = table.Column<int>(maxLength: 2, nullable: false),
                    TimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogadores_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 15, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    TorneioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Torneios_TorneioId",
                        column: x => x.TorneioId,
                        principalTable: "Torneios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimesDosGrupos",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 15, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Derrotas = table.Column<int>(nullable: false),
                    Empates = table.Column<int>(nullable: false),
                    GolsMarcados = table.Column<int>(nullable: false),
                    GolsSofridos = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: true),
                    IdDoTime = table.Column<int>(nullable: false),
                    NomeDoTime = table.Column<string>(nullable: false),
                    PontuacaoAtual = table.Column<int>(nullable: false),
                    Vitorias = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesDosGrupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimesDosGrupos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GolsDasPartidas_PartidaId",
                table: "GolsDasPartidas",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_TorneioId",
                table: "Grupos",
                column: "TorneioId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_TimeId",
                table: "Jogadores",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesDosGrupos_GrupoId",
                table: "TimesDosGrupos",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GolsDasPartidas");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Playoffs");

            migrationBuilder.DropTable(
                name: "TimesDosGrupos");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Torneios");
        }
    }
}
