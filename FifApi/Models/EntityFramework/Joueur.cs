﻿using System.ComponentModel.DataAnnotations;
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
        private int posteId;

   

        [Key]
        [Column("idJoueur", TypeName = "int")]
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

        [Column("nomJoueur", TypeName = "Varchar(150)")]
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

        [Column("prenomJoueur", TypeName = "Varchar(150)")]
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


        [Column("sexeJoueur", TypeName = "Char(1)")]
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

        [Column("dateNaissanceJoueur", TypeName = "Date")]
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

        [Column("dateDecesJoueur", TypeName = "Date")]
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

        [Column("debutCarriereJoueur", TypeName = "Date")]
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

        [Column("finCarriereJoueur", TypeName = "Date")]
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


        [Column("descriptionJoueur", TypeName = "Varchar(1000)")]
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

        [Column("posteId", TypeName = "int")]
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
        public virtual Poste PostePourJoueur { get; set; } = null!;

       
    }
}
