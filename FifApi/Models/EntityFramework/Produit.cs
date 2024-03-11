using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("Produit")]
    public class Produit
    {
        [Required]
        private int idProduit;
        private string nomProduit;
        private string descriptionProduit;
        private string caracteristiquesProduit;

        public Produit(int id, string nomProduit, string descriptionProduit, string caracteristiques)
        {
            this.IdProduit = id;
            this.NomProduit = nomProduit;
            this.DescriptionProduit = descriptionProduit;
            this.CaracteristiquesProduit = caracteristiques;
        }

        [Key]
        [Column("idproduit", TypeName = "int")]
        public int IdProduit
        {
            get { return idProduit; }
            set { idProduit = value; }
        }

        [Column("nomproduit", TypeName = "varchar(150)")]
        public string NomProduit
        {
            get { return nomProduit; }
            set { nomProduit = value; }
        }

        [Column("descriptionproduit", TypeName = "varchar(1000)")]
        public string DescriptionProduit
        {
            get { return descriptionProduit; }
            set { descriptionProduit = value; }
        }

        [Column("caracteristiquesproduit", TypeName = "varchar(500)")]
        public string CaracteristiquesProduit
        {
            get { return caracteristiquesProduit; }
            set { caracteristiquesProduit = value; }
        }




    }
}
