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
        public virtual DbSet<Couleur> Couleur { get; set; } = null!;
        public virtual DbSet<CouleurProduit> CouleurProduit { get; set; } = null!;
        public virtual DbSet<Taille> Taille { get; set; } = null!;
        public virtual DbSet<Stock> Stock { get; set; } = null!;
        public virtual DbSet<TypeProduit> TypeProduit { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            
                optionsBuilder.UseLoggerFactory(MyLoggerFactory).EnableSensitiveDataLogging().UseNpgsql("Server=localhost;port=5432;Database=FifaBDD; uid=postgres; password=postgres; ");
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
                entity.HasKey(e => new { e.IdJoueur })
                   .HasName("pk_joueur");

                entity.HasOne(d => d.PostePourJoueur)
                    .WithMany(p => p.JoueurPoste)
                    .HasForeignKey(d => d.PosteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_joueur_poste");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => new { e.IdProduit })
                   .HasName("pk_produit");

                entity.HasOne(d => d.MarqueduProduit)
                    .WithMany(p => p.ProduitMarque)
                    .HasForeignKey(d => d.MarqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produit_marque");

                entity.HasOne(d => d.TypePourLeProduit)
                   .WithMany(p => p.ProduitType)
                   .HasForeignKey(d => d.TypeId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_produit_Type");
            });

            modelBuilder.Entity<CouleurProduit>(entity =>
            {
                entity.HasKey(e => new { e.IdCouleurProduit })
                    .HasName("pk_couleurProduit");

                entity.HasOne(d => d.CouleurDuProduit)
                    .WithMany(p => p.ColoriationDuProduit)
                    .HasForeignKey(d => d.CouleurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_couleurProduit_couleur");

                entity.HasOne(d => d.ProduitAvecCouleur)
                    .WithMany(p => p.ColoriationDuProduit)
                    .HasForeignKey(d => d.ProduitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_couleurProduit_produit");
            });


            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => new { e.TailleId, e.CouleurProduitId })
                    .HasName("pk_stock");

                entity.HasOne(d => d.TailleDuProduit)
                    .WithMany(p => p.StockDuProduit)
                    .HasForeignKey(d => d.TailleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stock_taille");

                entity.HasOne(d => d.ProduitEnTaille)
                    .WithMany(p => p.StockDuProduit)
                    .HasForeignKey(d => d.CouleurProduitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stock_couleur");

            });

            modelBuilder.Entity<TypeProduit>(entity =>
            {
                entity.HasKey(e => new { e.IdType })
                   .HasName("pk_typeProduit");

                entity.HasOne(d => d.TypeEnSousType)
                    .WithMany(p => p.TypeDuProduit)
                    .HasForeignKey(d => d.SousTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_joueur_poste");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}
