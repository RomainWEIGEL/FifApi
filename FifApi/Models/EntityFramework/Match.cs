using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("Match")]
    public class Match
    {
        private int idMatch;
        private string scoreEquipeDomicile;
        private string scoreEquipeExterieure;
        private string nomMatch;
        private DateTime dateMatch;

        public Match(int idMatch, string scoreEquipeDomicile, string scoreEquipeExterieure, string nomMatch, DateTime dateMatch)
        {
            this.idMatch = idMatch;
            this.scoreEquipeDomicile = scoreEquipeDomicile;
            this.scoreEquipeExterieure = scoreEquipeExterieure;
            this.nomMatch = nomMatch;
            this.dateMatch = dateMatch;
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
        public string ScoreEquipeDomicile
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
        public string ScoreEquipeExterieure
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

        [Column("nomMatch", TypeName = "Vachar(50)")]
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
