﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("taille")]
    public class Taille
    {
        private string idTaille;
        private string nomTaille;
        private string descriptionTaille;

        public Taille(string idTaille, string nomTaille, string descriptionTaille)
        {
            this.idTaille = idTaille;
            this.nomTaille = nomTaille;
            this.descriptionTaille = descriptionTaille;
        }

        [Key]
        [Column("idTaille", TypeName = "char(6)")]
        public string IdTaille
        {
            get
            {
                return idTaille;
            }

            set
            {
                idTaille = value;
            }
        }

        [Column("nomTaille", TypeName = "Varchar(50)")]
        public string NomTaille
        {
            get
            {
                return nomTaille;
            }

            set
            {
                nomTaille = value;
            }
        }

        [Column("nomTaille", TypeName = "Varchar(100)")]
        public string DescriptionTaille
        {
            get
            {
                return this.descriptionTaille;
            }

            set
            {
                this.descriptionTaille = value;
            }
        }
    }
}