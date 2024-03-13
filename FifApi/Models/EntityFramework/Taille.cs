using System.ComponentModel.DataAnnotations;
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
        [Column("idtaille", TypeName = "char(6)")]
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

        [Column("nomtaille", TypeName = "Varchar(50)")]
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

        [Column("descriptiontaille", TypeName = "Varchar(100)")]
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

        [InverseProperty("TailleDuProduit")]
        public virtual ICollection<Stock> StockDuProduit { get; set; }
    }
}
