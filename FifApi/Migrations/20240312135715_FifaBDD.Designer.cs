﻿// <auto-generated />
using System;
using FifApi.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FifApi.Migrations
{
    [DbContext(typeof(FootDBContext))]
    [Migration("20240312135715_FifaBDD")]
    partial class FifaBDD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FifApi.Models.EntityFramework.Joueur", b =>
                {
                    b.Property<int>("IdJoueur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idJoueur");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdJoueur"));

                    b.Property<DateTime>("DateDecesJoueur")
                        .HasColumnType("Date")
                        .HasColumnName("dateDecesJoueur");

                    b.Property<DateTime>("DateNaissanceJoueur")
                        .HasColumnType("Date")
                        .HasColumnName("dateNaissanceJoueur");

                    b.Property<DateTime>("DebutCarriereJoueur")
                        .HasColumnType("Date")
                        .HasColumnName("debutCarriereJoueur");

                    b.Property<string>("DescriptionJoueur")
                        .IsRequired()
                        .HasColumnType("Varchar(1000)")
                        .HasColumnName("descriptionJoueur");

                    b.Property<DateTime>("FinCarriereJoueur")
                        .HasColumnType("Date")
                        .HasColumnName("finCarriereJoueur");

                    b.Property<string>("NomJoueur")
                        .IsRequired()
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("nomJoueur");

                    b.Property<int>("PosteId")
                        .HasColumnType("int")
                        .HasColumnName("posteId");

                    b.Property<string>("PrenomJoueur")
                        .IsRequired()
                        .HasColumnType("Varchar(150)")
                        .HasColumnName("prenomJoueur");

                    b.Property<string>("SexeJoueur")
                        .IsRequired()
                        .HasColumnType("Char(1)")
                        .HasColumnName("sexeJoueur");

                    b.HasKey("IdJoueur");

                    b.ToTable("Joueur");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.JoueurMatch", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int")
                        .HasColumnName("matchId");

                    b.Property<int>("JoueurId")
                        .HasColumnType("int")
                        .HasColumnName("joueurId");

                    b.Property<int>("NbButs")
                        .HasColumnType("int")
                        .HasColumnName("nbButs");

                    b.HasKey("MatchId", "JoueurId")
                        .HasName("pk_avis");

                    b.HasIndex("JoueurId");

                    b.ToTable("JoueurMatch");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Match", b =>
                {
                    b.Property<int>("IdMatch")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idMatch");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMatch"));

                    b.Property<DateTime>("DateMatch")
                        .HasColumnType("Date")
                        .HasColumnName("dateMatch");

                    b.Property<string>("NomMatch")
                        .IsRequired()
                        .HasColumnType("Vachar(50)")
                        .HasColumnName("nomMatch");

                    b.Property<int>("ScoreEquipeDomicile")
                        .HasColumnType("int")
                        .HasColumnName("scoreEquipeDomicile");

                    b.Property<int>("ScoreEquipeExterieure")
                        .HasColumnType("int")
                        .HasColumnName("scoreEquipeExterieure");

                    b.HasKey("IdMatch");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.JoueurMatch", b =>
                {
                    b.HasOne("FifApi.Models.EntityFramework.Joueur", "JoueurDansMatch")
                        .WithMany("JouabiliteMatch")
                        .HasForeignKey("JoueurId")
                        .IsRequired()
                        .HasConstraintName("fk_notation_utilisateur");

                    b.HasOne("FifApi.Models.EntityFramework.Match", "MatchPourJoueur")
                        .WithMany("JouabiliteMatch")
                        .HasForeignKey("MatchId")
                        .IsRequired()
                        .HasConstraintName("fk_notation_film");

                    b.Navigation("JoueurDansMatch");

                    b.Navigation("MatchPourJoueur");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Joueur", b =>
                {
                    b.Navigation("JouabiliteMatch");
                });

            modelBuilder.Entity("FifApi.Models.EntityFramework.Match", b =>
                {
                    b.Navigation("JouabiliteMatch");
                });
#pragma warning restore 612, 618
        }
    }
}
