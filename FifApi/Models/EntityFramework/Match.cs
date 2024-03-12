using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("Match")]
    public class Match
    {
        private int idMatch;
        private int scoreEquipeDomicile;
        private int scoreEquipeExterieure;
        private string nomMatch;
        private DateTime dateMatch;

        public Match(int idMatch, int scoreEquipeDomicile, int scoreEquipeExterieure, string nomMatch, DateTime dateMatch)
        {
            this.IdMatch = idMatch;
            this.ScoreEquipeDomicile = scoreEquipeDomicile;
            this.ScoreEquipeExterieure = scoreEquipeExterieure;
            this.NomMatch = nomMatch;
            this.DateMatch = dateMatch;
        }

        [Key]
        [Column("idMatch", TypeName = "int")]
        public int IdMatch
        {
            get
            {
                return idMatch;
            }

            set
            {
                idMatch = value;
            }
        }

        [Column("scoreEquipeDomicile", TypeName = "int")]
        public int ScoreEquipeDomicile
        {
            get
            {
                return scoreEquipeDomicile;
            }

            set
            {
                scoreEquipeDomicile = value;
            }
        }

        [Column("scoreEquipeExterieure", TypeName = "int")]
        public int ScoreEquipeExterieure
        {
            get
            {
                return scoreEquipeExterieure;
            }

            set
            {
                scoreEquipeExterieure = value;
            }
        }

        [Column("nomMatch", TypeName = "Varchar(50)")]
        public string NomMatch
        {
            get
            {
                return nomMatch;
            }

            set
            {
                nomMatch = value;
            }
        }
        
        [Column("dateMatch", TypeName = "Date")]
        public DateTime DateMatch
        {
            get
            {
                return this.dateMatch;
            }

            set
            {
                this.dateMatch = value;
            }
        }

        [InverseProperty("MatchPourJoueur")]
        public virtual ICollection<JoueurMatch> JouabiliteMatch { get; set; }
    }
}
