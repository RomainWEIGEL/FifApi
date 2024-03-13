using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("joueur")]
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
        private int posteId;

       

        public Joueur(int idJoueur, string nomJoueur, string prenomJoueur, string sexeJoueur, DateTime dateNaissanceJoueur, DateTime dateDecesJoueur, DateTime debutCarriereJoueur, DateTime finCarriereJoueur, string descriptionJoueur, int posteId)
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
            this.PosteId = posteId;
        }

        [Key]
        [Column("idjoueur", TypeName = "int")]
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

        [Column("nomjoueur", TypeName = "Varchar(150)")]
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

        [Column("prenomjoueur", TypeName = "Varchar(150)")]
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


        [Column("sexejoueur", TypeName = "Char(1)")]
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

        [Column("datenaissancejoueur", TypeName = "Date")]
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

        [Column("datedecesjoueur", TypeName = "Date")]
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

        [Column("debutcarrierejoueur", TypeName = "Date")]
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

        [Column("fincarrierejoueur", TypeName = "Date")]
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


        [Column("descriptionjoueur", TypeName = "Varchar(1000)")]
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

        [Column("posteid", TypeName = "int")]
        public int PosteId
        {
            get
            {
                return this.posteId;
            }

            set
            {
                this.posteId = value;
            }
        }

        [InverseProperty("JoueurDansMatch")]
        public virtual ICollection<JoueurMatch> JouabiliteMatch { get; set; }

        [ForeignKey("PosteId")]
        [InverseProperty("JoueurPoste")]
        public virtual Poste PostePourJoueur { get; set; }


    }
}
