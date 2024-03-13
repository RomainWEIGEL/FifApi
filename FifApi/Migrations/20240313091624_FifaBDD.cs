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
                    idmarque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nommarque = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marque", x => x.idmarque);
                });

            migrationBuilder.CreateTable(
                name: "match",
                columns: table => new
                {
                    idmatch = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scoreequipedomicile = table.Column<int>(type: "int", nullable: false),
                    scoreequipeexterieure = table.Column<int>(type: "int", nullable: false),
                    nommatch = table.Column<string>(type: "Varchar(50)", nullable: false),
                    datematch = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match", x => x.idmatch);
                });

            migrationBuilder.CreateTable(
                name: "poste",
                columns: table => new
                {
                    idposte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomposte = table.Column<string>(type: "Varchar(150)", nullable: false),
                    descriptionposte = table.Column<string>(type: "Varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poste", x => x.idposte);
                });

            migrationBuilder.CreateTable(
                name: "taille",
                columns: table => new
                {
                    idtaille = table.Column<string>(type: "char(6)", nullable: false),
                    nomtaille = table.Column<string>(type: "Varchar(50)", nullable: false),
                    descriptiontaille = table.Column<string>(type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taille", x => x.idtaille);
                });

            migrationBuilder.CreateTable(
                name: "typeproduit",
                columns: table => new
                {
                    idtype = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomtype = table.Column<string>(type: "varchar(100)", nullable: false),
                    descriptiontype = table.Column<string>(type: "varchar(150)", nullable: false),
                    soustypeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typeProduit", x => x.idtype);
                    table.ForeignKey(
                        name: "fk_joueur_poste",
                        column: x => x.soustypeid,
                        principalTable: "typeproduit",
                        principalColumn: "idtype");
                });

            migrationBuilder.CreateTable(
                name: "joueur",
                columns: table => new
                {
                    idjoueur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomjoueur = table.Column<string>(type: "Varchar(150)", nullable: false),
                    prenomjoueur = table.Column<string>(type: "Varchar(150)", nullable: false),
                    sexejoueur = table.Column<string>(type: "Char(1)", nullable: false),
                    datenaissancejoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    datedecesjoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    debutcarrierejoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    fincarrierejoueur = table.Column<DateTime>(type: "Date", nullable: false),
                    descriptionjoueur = table.Column<string>(type: "Varchar(1000)", nullable: false),
                    posteid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_joueur", x => x.idjoueur);
                    table.ForeignKey(
                        name: "fk_joueur_poste",
                        column: x => x.posteid,
                        principalTable: "poste",
                        principalColumn: "idposte");
                });

            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    idproduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomproduit = table.Column<string>(type: "varchar(150)", nullable: false),
                    descriptionproduit = table.Column<string>(type: "varchar(1000)", nullable: false),
                    caracteristiquesproduit = table.Column<string>(type: "varchar(500)", nullable: false),
                    marqueid = table.Column<int>(type: "int", nullable: false),
                    typeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produit", x => x.idproduit);
                    table.ForeignKey(
                        name: "fk_produit_marque",
                        column: x => x.marqueid,
                        principalTable: "marque",
                        principalColumn: "idmarque");
                    table.ForeignKey(
                        name: "fk_produit_Type",
                        column: x => x.typeid,
                        principalTable: "typeproduit",
                        principalColumn: "idtype");
                });

            migrationBuilder.CreateTable(
                name: "joueurmatch",
                columns: table => new
                {
                    joueurid = table.Column<int>(type: "int", nullable: false),
                    matchid = table.Column<int>(type: "int", nullable: false),
                    nbbuts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_joueurMatch", x => new { x.matchid, x.joueurid });
                    table.ForeignKey(
                        name: "fk_joueurMatch_joueur",
                        column: x => x.joueurid,
                        principalTable: "joueur",
                        principalColumn: "idjoueur");
                    table.ForeignKey(
                        name: "fk_joueurMatch_match",
                        column: x => x.matchid,
                        principalTable: "match",
                        principalColumn: "idmatch");
                });

            migrationBuilder.CreateTable(
                name: "couleurproduit",
                columns: table => new
                {
                    idcouleurproduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prix = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    codebarre = table.Column<string>(type: "varchar(48)", nullable: false),
                    produitid = table.Column<int>(type: "int", nullable: false),
                    couleurid = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_couleurProduit", x => x.idcouleurproduit);
                    table.ForeignKey(
                        name: "fk_couleurProduit_couleur",
                        column: x => x.couleurid,
                        principalTable: "couleur",
                        principalColumn: "idcouleur");
                    table.ForeignKey(
                        name: "fk_couleurProduit_produit",
                        column: x => x.produitid,
                        principalTable: "produit",
                        principalColumn: "idproduit");
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    tailleid = table.Column<string>(type: "char(6)", nullable: false),
                    couleurproduitid = table.Column<int>(type: "int", nullable: false),
                    quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock", x => new { x.tailleid, x.couleurproduitid });
                    table.ForeignKey(
                        name: "fk_stock_couleur",
                        column: x => x.couleurproduitid,
                        principalTable: "couleurproduit",
                        principalColumn: "idcouleurproduit");
                    table.ForeignKey(
                        name: "fk_stock_taille",
                        column: x => x.tailleid,
                        principalTable: "taille",
                        principalColumn: "idtaille");
                });

            migrationBuilder.CreateIndex(
                name: "IX_couleurproduit_couleurid",
                table: "couleurproduit",
                column: "couleurid");

            migrationBuilder.CreateIndex(
                name: "IX_couleurproduit_produitid",
                table: "couleurproduit",
                column: "produitid");

            migrationBuilder.CreateIndex(
                name: "IX_joueur_posteid",
                table: "joueur",
                column: "posteid");

            migrationBuilder.CreateIndex(
                name: "IX_joueurmatch_joueurid",
                table: "joueurmatch",
                column: "joueurid");

            migrationBuilder.CreateIndex(
                name: "IX_produit_marqueid",
                table: "produit",
                column: "marqueid");

            migrationBuilder.CreateIndex(
                name: "IX_produit_typeid",
                table: "produit",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_stock_couleurproduitid",
                table: "stock",
                column: "couleurproduitid");

            migrationBuilder.CreateIndex(
                name: "IX_typeproduit_soustypeid",
                table: "typeproduit",
                column: "soustypeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "joueurmatch");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "joueur");

            migrationBuilder.DropTable(
                name: "match");

            migrationBuilder.DropTable(
                name: "couleurproduit");

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

            migrationBuilder.DropTable(
                name: "typeproduit");
        }
    }
}
