using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("joueurMatch")]
    public class JoueurMatch
    {
        private int joueurId;
        private int matchId;
        private int nbButs;

        public JoueurMatch(int joueurId, int matchId, int nbButs)
        {
            this.joueurId = joueurId;
            this.matchId = matchId;
            this.nbButs = nbButs;
        }

        [Key]
        [Column("joueurId", TypeName = "int")]
        public int JoueurId
        {
            get
            {
                return joueurId;
            }

            set
            {
                joueurId = value;
            }
        }

        [Key]
        [Column("matchId", TypeName = "int")]
        public int MatchId
        {
            get
            {
                return matchId;
            }

            set
            {
                matchId = value;
            }
        }

        [Column("nbButs", TypeName = "int")]
        public int NbButs
        {
            get
            {
                return this.nbButs;
            }

            set
            {
                this.nbButs = value;
            }
        }


        [ForeignKey("JoueurId")]
        [InverseProperty("JouabiliteMatch")]
        public virtual Joueur JoueurDansMatch { get; set; } = null!;
        [ForeignKey("MatchId")]
        [InverseProperty("JouabiliteMatch")]
        public virtual Match MatchPourJoueur { get; set; } = null!;
    }
}
