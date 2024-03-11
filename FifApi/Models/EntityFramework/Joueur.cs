using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("Joueur")]
    public class Joueur
    {
        private int idJoueur;
        private string nomJoueur;
        private string prenomJoueur;
        private string sexeJoueur;
        private DateTime dateNaissanceJoueur;
        private DateTime dateDecesJoueur;
        private DateTime debutCarriereJoueur;
        private DateTime finCarriereJoueur;
        private string descriptionJoueur;

        public Joueur(int idJoueur, string nomJoueur, string prenomJoueur, string sexeJoueur, DateTime dateNaissanceJoueur, DateTime dateDecesJoueur, DateTime debutCarriereJoueur, DateTime finCarriereJoueur, string descriptionJoueur)
        {
            this.idJoueur = idJoueur;
            this.nomJoueur = nomJoueur;
            this.prenomJoueur = prenomJoueur;
            this.sexeJoueur = sexeJoueur;
            this.dateNaissanceJoueur = dateNaissanceJoueur;
            this.dateDecesJoueur = dateDecesJoueur;
            this.debutCarriereJoueur = debutCarriereJoueur;
            this.finCarriereJoueur = finCarriereJoueur;
            this.descriptionJoueur = descriptionJoueur;
        }

        [Key]
        [Column("IdJoueur", TypeName = "int")]
        public int IdJoueur
        {
            get
            {
                return idJoueur;
            }

            set
            {
                idJoueur = value;
            }
        }

        [Column("NomJoueur", TypeName = "Varchar(150)")]
        public string NomJoueur
        {
            get
            {
                return nomJoueur;
            }

            set
            {
                nomJoueur = value;
            }
        }

        [Column("NomJoueur", TypeName = "Varchar(150)")]
        public string PrenomJoueur
        {
            get
            {
                return prenomJoueur;
            }

            set
            {
                prenomJoueur = value;
            }
        }


        [Column("SexeJoueur", TypeName = "Char(1)")]
        public string SexeJoueur
        {
            get
            {
                return sexeJoueur;
            }

            set
            {
                sexeJoueur = value;
            }
        }

        [Column("DateNaissanceJoueur", TypeName = "Date")]
        public DateTime DateNaissanceJoueur
        {
            get
            {
                return dateNaissanceJoueur;
            }

            set
            {
                dateNaissanceJoueur = value;
            }
        }

        [Column("DateDecesJoueur", TypeName = "Date")]
        public DateTime DateDecesJoueur
        {
            get
            {
                return dateDecesJoueur;
            }

            set
            {
                dateDecesJoueur = value;
            }
        }

        [Column("DebutCarriereJoueur", TypeName = "Date")]
        public DateTime DebutCarriereJoueur
        {
            get
            {
                return debutCarriereJoueur;
            }

            set
            {
                debutCarriereJoueur = value;
            }
        }

        [Column("FinCarriereJoueur", TypeName = "Date")]
        public DateTime FinCarriereJoueur
        {
            get
            {
                return finCarriereJoueur;
            }

            set
            {
                finCarriereJoueur = value;
            }
        }


        [Column("FinCarriereJoueur", TypeName = "Varchar(1000)")]
        public string DescriptionJoueur
        {
            get
            {
                return this.descriptionJoueur;
            }

            set
            {
                this.descriptionJoueur = value;
            }
        }

       // [InverseProperty("JoueurMatch")]
        //public virtual ICollection<t_j_notation_not> Notation { get; set; }
    }
}
