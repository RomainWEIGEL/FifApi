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
                name: "couleur",
                columns: table => new
                {
                    idcouleur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomproduit = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_couleur", x => x.idcouleur);
                });

            migrationBuilder.CreateTable(
                name: "marque",
                columns: table => new
                {
                    idMarque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomMarque = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marque", x => x.idMarque);
                });

            migrationBuilder.CreateTable(
                name: "match",
                columns: table => new
                {
                    idMatch = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scoreEquipeDomicile = table.Column<int>(type: "int", nullable: false),
                    scoreEquipeExterieure = table.Column<int>(type: "int", nullable: false),
                    nomMatch = table.Column<string>(type: "Varchar(50)", nullable: false),
                    dateMatch = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match", x => x.idMatch);
                });

            migrationBuilder.CreateTable(
                name: "poste",
                columns: table => new
                {
                    idposte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomPoste = table.Column<string>(type: "Varchar(150)", nullable: false),
                    descriptionPoste = table.Column<string>(type: "Varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poste", x => x.idposte);
                });

            migrationBuilder.CreateTable(
                name: "taille",
                columns: table => new
                {
                    idTaille = table.Column<string>(type: "char(6)", nullable: false),
                    nomTaille = table.Column<string>(type: "Varchar(50)", nullable: false),
                    descriptionTaille = table.Column<string>(type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taille", x => x.idTaille);
                });

            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    MarqueId = table.Column<int>(type: "int", nullable: false),
                    idproduit = table.Column<int>(type: "int", nullable: false),
                    nomproduit = table.Column<string>(type: "varchar(150)", nullable: false),
                    descriptionproduit = table.Column<string>(type: "varchar(1000)", nullable: false),
                    caracteristiquesproduit = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produit", x => x.MarqueId);
                    table.ForeignKey(
                        name: "fk_produit_marque",
                        column: x => x.MarqueId,
                        principalTable: "marque",
                        principalColumn: "idMarque");
                });

            migrationBuilder.CreateTable(
                name: "joueur",
                columns: table => new
                {
                    posteId = table.Column<int>(type: "int", nullable: false),
                    idJoueur = table.Column<int>(type: "int", nullable: false),
                    nomJoueur = table.Column<string>(type: "Varchar(150)", nullable: false),
                    prenomJoueur = table.Column<string>(type: "Varchar(150)", nullable: false),
                    sexeJoueur = table.Column<string>(type: "Char(1)", nullable: false),
                    dateNaissanceJoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    dateDecesJoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    debutCarriereJoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    finCarriereJoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    descriptionJoueur = table.Column<string>(type: "Varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_joueur", x => x.posteId);
                    table.ForeignKey(
                        name: "fk_joueur_poste",
                        column: x => x.posteId,
                        principalTable: "poste",
                        principalColumn: "idposte");
                });

            migrationBuilder.CreateTable(
                name: "CouleurProduit",
                columns: table => new
                {
                    idCouleurProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prix = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    codebarre = table.Column<string>(type: "varchar(48)", nullable: false),
                    produitId = table.Column<int>(type: "int", nullable: false),
                    couleurId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_couleurProduit", x => x.idCouleurProduit);
                    table.ForeignKey(
                        name: "fk_couleurProduit_couleur",
                        column: x => x.couleurId,
                        principalTable: "couleur",
                        principalColumn: "idcouleur");
                    table.ForeignKey(
                        name: "fk_couleurProduit_produit",
                        column: x => x.produitId,
                        principalTable: "produit",
                        principalColumn: "MarqueId");
                });

            migrationBuilder.CreateTable(
                name: "joueurMatch",
                columns: table => new
                {
                    joueurId = table.Column<int>(type: "int", nullable: false),
                    matchId = table.Column<int>(type: "int", nullable: false),
                    nbButs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_joueurMatch", x => new { x.matchId, x.joueurId });
                    table.ForeignKey(
                        name: "fk_joueurMatch_joueur",
                        column: x => x.joueurId,
                        principalTable: "joueur",
                        principalColumn: "posteId");
                    table.ForeignKey(
                        name: "fk_joueurMatch_match",
                        column: x => x.matchId,
                        principalTable: "match",
                        principalColumn: "idMatch");
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    tailleId = table.Column<string>(type: "char(6)", nullable: false),
                    couleurProduitId = table.Column<int>(type: "int", nullable: false),
                    quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock", x => new { x.tailleId, x.couleurProduitId });
                    table.ForeignKey(
                        name: "fk_stock_couleur",
                        column: x => x.couleurProduitId,
                        principalTable: "CouleurProduit",
                        principalColumn: "idCouleurProduit");
                    table.ForeignKey(
                        name: "fk_stock_taille",
                        column: x => x.tailleId,
                        principalTable: "taille",
                        principalColumn: "idTaille");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouleurProduit_couleurId",
                table: "CouleurProduit",
                column: "couleurId");

            migrationBuilder.CreateIndex(
                name: "IX_CouleurProduit_produitId",
                table: "CouleurProduit",
                column: "produitId");

            migrationBuilder.CreateIndex(
                name: "IX_joueurMatch_joueurId",
                table: "joueurMatch",
                column: "joueurId");

            migrationBuilder.CreateIndex(
                name: "IX_stock_couleurProduitId",
                table: "stock",
                column: "couleurProduitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "joueurMatch");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "joueur");

            migrationBuilder.DropTable(
                name: "match");

            migrationBuilder.DropTable(
                name: "CouleurProduit");

            migrationBuilder.DropTable(
                name: "taille");

            migrationBuilder.DropTable(
                name: "poste");

            migrationBuilder.DropTable(
                name: "couleur");

            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "marque");
        }
    }
}
