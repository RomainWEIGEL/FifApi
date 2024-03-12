using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FifApi.Migrations
{
    public partial class FifaBDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    idJoueur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomJoueur = table.Column<string>(type: "Varchar(150)", nullable: false),
                    prenomJoueur = table.Column<string>(type: "Varchar(150)", nullable: false),
                    sexeJoueur = table.Column<string>(type: "Char(1)", nullable: false),
                    dateNaissanceJoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    dateDecesJoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    debutCarriereJoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    finCarriereJoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    descriptionJoueur = table.Column<string>(type: "Varchar(1000)", nullable: false),
                    posteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.idJoueur);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    idMatch = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scoreEquipeDomicile = table.Column<int>(type: "int", nullable: false),
                    scoreEquipeExterieure = table.Column<int>(type: "int", nullable: false),
                    nomMatch = table.Column<string>(type: "Vachar(50)", nullable: false),
                    dateMatch = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.idMatch);
                });

            migrationBuilder.CreateTable(
                name: "JoueurMatch",
                columns: table => new
                {
                    joueurId = table.Column<int>(type: "int", nullable: false),
                    matchId = table.Column<int>(type: "int", nullable: false),
                    nbButs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_avis", x => new { x.matchId, x.joueurId });
                    table.ForeignKey(
                        name: "fk_notation_film",
                        column: x => x.matchId,
                        principalTable: "Match",
                        principalColumn: "idMatch");
                    table.ForeignKey(
                        name: "fk_notation_utilisateur",
                        column: x => x.joueurId,
                        principalTable: "Joueur",
                        principalColumn: "idJoueur");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoueurMatch_joueurId",
                table: "JoueurMatch",
                column: "joueurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoueurMatch");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Joueur");
        }
    }
}
