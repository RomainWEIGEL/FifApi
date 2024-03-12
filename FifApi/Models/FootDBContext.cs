using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FifApi.Models.EntityFramework
{
    public partial  class FootDBContext: DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        public FootDBContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<JoueurMatch> JouabiliteMatch { get; set; } = null!;
        public virtual DbSet<Joueur> Joueur { get; set; } = null!;
        public virtual DbSet<Match> Match { get; set; } = null!;
        public virtual DbSet<Poste> Poste { get; set; } = null!;
        public virtual DbSet<Produit> Produit { get; set; } = null!;
        public virtual DbSet<Marque> Marque { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            
                optionsBuilder.UseLoggerFactory(MyLoggerFactory).EnableSensitiveDataLogging().UseNpgsql("Server=localhost;port=5432;Database=FifaBDD; uid=postgres; password =postgres; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoueurMatch>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.JoueurId })
                    .HasName("pk_joueurMatch");

                entity.HasOne(d => d.MatchPourJoueur)
                    .WithMany(p => p.JouabiliteMatch)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_joueurMatch_match");

                entity.HasOne(d => d.JoueurDansMatch)
                    .WithMany(p => p.JouabiliteMatch)
                    .HasForeignKey(d => d.JoueurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_joueurMatch_joueur");
            });

            modelBuilder.Entity<Joueur>(entity =>
            {
                entity.HasKey(e => new { e.PosteId })
                   .HasName("pk_joueur");

                entity.HasOne(d => d.PostePourJoueur)
                    .WithMany(p => p.JoueurPoste)
                    .HasForeignKey(d => d.PosteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_joueur_poste");
            });
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => new { e.MarqueId })
                   .HasName("pk_produit");

                entity.HasOne(d => d.MarqueduProduit)
                    .WithMany(p => p.ProduitMarque)
                    .HasForeignKey(d => d.MarqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produit_marque");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}
