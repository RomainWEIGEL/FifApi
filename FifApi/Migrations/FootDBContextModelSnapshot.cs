﻿// <auto-generated />
using System;
using FifApi.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FifApi.Migrations
{
    [DbContext(typeof(FootDBContext))]
    partial class FootDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FifApi.Models.EntityFramework.Couleur", b =>
                {
                    b.Property<int>("IdCouleur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idcouleur");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCouleur"));

                    b.Property<string>("NomCouleur")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nomproduit");

                    b.HasKey("IdCouleur");

                    b.ToTable("couleur");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.CouleurProduit", b =>
                {
                    b.Property<int>("IdCouleurProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idcouleurproduit");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCouleurProduit"));

                    b.Property<string>("CodeBarre")
                        .IsRequired()
                        .HasColumnType("varchar(48)")
                        .HasColumnName("codebarre");

                    b.Property<int>("CouleurId")
                        .HasColumnType("int")
                        .HasColumnName("couleurid");

                    b.Property<int>("MatchId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Prix")
                        .HasColumnType("numeric(8,2)")
                        .HasColumnName("prix");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int")
                        .HasColumnName("produitid");

                    b.HasKey("IdCouleurProduit")
                        .HasName("pk_couleurProduit");

                    b.HasIndex("CouleurId");

                    b.HasIndex("ProduitId");

                    b.ToTable("couleurproduit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Joueur", b =>
                {
                    b.Property<int>("IdJoueur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idjoueur");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdJoueur"));

                    b.Property<DateTime>("DateDecesJoueur")
                        .HasColumnType("Date")
                        .HasColumnName("datedecesjoueur");

                    b.Property<DateTime>("DateNaissanceJoueur")
                        .HasColumnType("Date")
                        .HasColumnName("datenaissancejoueur");

                    b.Property<DateTime>("DebutCarriereJoueur")
                        .HasColumnType("Date")
                        .HasColumnName("debutcarrierejoueur");

                    b.Property<string>("DescriptionJoueur")
                        .IsRequired()
                        .HasColumnType("Varchar(1000)")
                        .HasColumnName("descriptionjoueur");

                    b.Property<DateTime>("FinCarriereJoueur")
                        .HasColumnType("Date")
                        .HasColumnName("fincarrierejoueur");

                    b.Property<string>("NomJoueur")
                        .IsRequired()
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("nomjoueur");

                    b.Property<int>("PosteId")
                        .HasColumnType("int")
                        .HasColumnName("posteid");

                    b.Property<string>("PrenomJoueur")
                        .IsRequired()
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("prenomjoueur");

                    b.Property<string>("SexeJoueur")
                        .IsRequired()
                        .HasColumnType("Char(1)")
                        .HasColumnName("sexejoueur");

                    b.HasKey("IdJoueur")
                        .HasName("pk_joueur");

                    b.HasIndex("PosteId");

                    b.ToTable("joueur");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.JoueurMatch", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int")
                        .HasColumnName("matchid");

                    b.Property<int>("JoueurId")
                        .HasColumnType("int")
                        .HasColumnName("joueurid");

                    b.Property<int>("NbButs")
                        .HasColumnType("int")
                        .HasColumnName("nbbuts");

                    b.HasKey("MatchId", "JoueurId")
                        .HasName("pk_joueurMatch");

                    b.HasIndex("JoueurId");

                    b.ToTable("joueurmatch");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Marque", b =>
                {
                    b.Property<int>("IdMarque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idmarque");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMarque"));

                    b.Property<string>("NomMarque")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nommarque");

                    b.HasKey("IdMarque");

                    b.ToTable("marque");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Match", b =>
                {
                    b.Property<int>("IdMatch")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idmatch");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMatch"));

                    b.Property<DateTime>("DateMatch")
                        .HasColumnType("Date")
                        .HasColumnName("datematch");

                    b.Property<string>("NomMatch")
                        .IsRequired()
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("nommatch");

                    b.Property<int>("ScoreEquipeDomicile")
                        .HasColumnType("int")
                        .HasColumnName("scoreequipedomicile");

                    b.Property<int>("ScoreEquipeExterieure")
                        .HasColumnType("int")
                        .HasColumnName("scoreequipeexterieure");

                    b.HasKey("IdMatch");

                    b.ToTable("match");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Poste", b =>
                {
                    b.Property<int>("Idposte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idposte");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Idposte"));

                    b.Property<string>("DescriptionPoste")
                        .IsRequired()
                        .HasColumnType("Varchar(300)")
                        .HasColumnName("descriptionposte");

                    b.Property<string>("NomPoste")
                        .IsRequired()
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("nomposte");

                    b.HasKey("Idposte");

                    b.ToTable("poste");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Produit", b =>
                {
                    b.Property<int>("IdProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idproduit");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduit"));

                    b.Property<string>("CaracteristiquesProduit")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("caracteristiquesproduit");

                    b.Property<string>("DescriptionProduit")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("descriptionproduit");

                    b.Property<int>("MarqueId")
                        .HasColumnType("int")
                        .HasColumnName("marqueid");

                    b.Property<string>("NomProduit")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nomproduit");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("typeid");

                    b.HasKey("IdProduit")
                        .HasName("pk_produit");

                    b.HasIndex("MarqueId");

                    b.HasIndex("TypeId");

                    b.ToTable("produit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Stock", b =>
                {
                    b.Property<string>("TailleId")
                        .HasColumnType("char(6)")
                        .HasColumnName("tailleid");

                    b.Property<int>("CouleurProduitId")
                        .HasColumnType("int")
                        .HasColumnName("couleurproduitid");

                    b.Property<int>("Quantite")
                        .HasColumnType("int")
                        .HasColumnName("quantite");

                    b.HasKey("TailleId", "CouleurProduitId")
                        .HasName("pk_stock");

                    b.HasIndex("CouleurProduitId");

                    b.ToTable("stock");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Taille", b =>
                {
                    b.Property<string>("IdTaille")
                        .HasColumnType("char(6)")
                        .HasColumnName("idtaille");

                    b.Property<string>("DescriptionTaille")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("descriptiontaille");

                    b.Property<string>("NomTaille")
                        .IsRequired()
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("nomtaille");

                    b.HasKey("IdTaille");

                    b.ToTable("taille");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.TypeProduit", b =>
                {
                    b.Property<int>("IdType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idtype");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdType"));

                    b.Property<string>("DescriptionType")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("descriptiontype");

                    b.Property<string>("NomType")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nomtype");

                    b.Property<int>("SousTypeId")
                        .HasColumnType("int")
                        .HasColumnName("soustypeid");

                    b.HasKey("IdType")
                        .HasName("pk_typeProduit");

                    b.HasIndex("SousTypeId");

                    b.ToTable("typeproduit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.CouleurProduit", b =>
                {
                    b.HasOne("FifApi.Models.EntityFramework.Couleur", "CouleurDuProduit")
                        .WithMany("ColoriationDuProduit")
                        .HasForeignKey("CouleurId")
                        .IsRequired()
                        .HasConstraintName("fk_couleurProduit_couleur");

                    b.HasOne("FifApi.Models.EntityFramework.Produit", "ProduitAvecCouleur")
                        .WithMany("ColoriationDuProduit")
                        .HasForeignKey("ProduitId")
                        .IsRequired()
                        .HasConstraintName("fk_couleurProduit_produit");

                    b.Navigation("CouleurDuProduit");

                    b.Navigation("ProduitAvecCouleur");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Joueur", b =>
                {
                    b.HasOne("FifApi.Models.EntityFramework.Poste", "PostePourJoueur")
                        .WithMany("JoueurPoste")
                        .HasForeignKey("PosteId")
                        .IsRequired()
                        .HasConstraintName("fk_joueur_poste");

                    b.Navigation("PostePourJoueur");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.JoueurMatch", b =>
                {
                    b.HasOne("FifApi.Models.EntityFramework.Joueur", "JoueurDansMatch")
                        .WithMany("JouabiliteMatch")
                        .HasForeignKey("JoueurId")
                        .IsRequired()
                        .HasConstraintName("fk_joueurMatch_joueur");

                    b.HasOne("FifApi.Models.EntityFramework.Match", "MatchPourJoueur")
                        .WithMany("JouabiliteMatch")
                        .HasForeignKey("MatchId")
                        .IsRequired()
                        .HasConstraintName("fk_joueurMatch_match");

                    b.Navigation("JoueurDansMatch");

                    b.Navigation("MatchPourJoueur");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Produit", b =>
                {
                    b.HasOne("FifApi.Models.EntityFramework.Marque", "MarqueduProduit")
                        .WithMany("ProduitMarque")
                        .HasForeignKey("MarqueId")
                        .IsRequired()
                        .HasConstraintName("fk_produit_marque");

                    b.HasOne("FifApi.Models.EntityFramework.TypeProduit", "TypePourLeProduit")
                        .WithMany("ProduitType")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("fk_produit_Type");

                    b.Navigation("MarqueduProduit");

                    b.Navigation("TypePourLeProduit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Stock", b =>
                {
                    b.HasOne("FifApi.Models.EntityFramework.CouleurProduit", "ProduitEnTaille")
                        .WithMany("StockDuProduit")
                        .HasForeignKey("CouleurProduitId")
                        .IsRequired()
                        .HasConstraintName("fk_stock_couleur");

                    b.HasOne("FifApi.Models.EntityFramework.Taille", "TailleDuProduit")
                        .WithMany("StockDuProduit")
                        .HasForeignKey("TailleId")
                        .IsRequired()
                        .HasConstraintName("fk_stock_taille");

                    b.Navigation("ProduitEnTaille");

                    b.Navigation("TailleDuProduit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.TypeProduit", b =>
                {
                    b.HasOne("FifApi.Models.EntityFramework.TypeProduit", "TypeEnSousType")
                        .WithMany("TypeDuProduit")
                        .HasForeignKey("SousTypeId")
                        .IsRequired()
                        .HasConstraintName("fk_joueur_poste");

                    b.Navigation("TypeEnSousType");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Couleur", b =>
                {
                    b.Navigation("ColoriationDuProduit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.CouleurProduit", b =>
                {
                    b.Navigation("StockDuProduit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Joueur", b =>
                {
                    b.Navigation("JouabiliteMatch");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Marque", b =>
                {
                    b.Navigation("ProduitMarque");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Match", b =>
                {
                    b.Navigation("JouabiliteMatch");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Poste", b =>
                {
                    b.Navigation("JoueurPoste");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Produit", b =>
                {
                    b.Navigation("ColoriationDuProduit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Taille", b =>
                {
                    b.Navigation("StockDuProduit");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.TypeProduit", b =>
                {
                    b.Navigation("ProduitType");

                    b.Navigation("TypeDuProduit");
                });
#pragma warning restore 612, 618
        }
    }
}
