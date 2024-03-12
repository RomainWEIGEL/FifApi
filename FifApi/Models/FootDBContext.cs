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
        public virtual DbSet<Joueur> Joueurs { get; set; } = null!;
        public virtual DbSet<Match> Matchs { get; set; } = null!;



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
                    .HasName("pk_avis");

                entity.HasOne(d => d.MatchPourJoueur)
                    .WithMany(p => p.JouabiliteMatch)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_notation_film");

                entity.HasOne(d => d.JoueurDansMatch)
                    .WithMany(p => p.JouabiliteMatch)
                    .HasForeignKey(d => d.JoueurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_notation_utilisateur");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}
