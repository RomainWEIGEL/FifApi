using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("produit")]
    public class Produit
    {
        [Required]
        private int idProduit;
        private string nomProduit;
        private string descriptionProduit;
        private string caracteristiquesProduit;
        private int marqueId;

        public Produit(int idProduit, string nomProduit, string descriptionProduit, string caracteristiquesProduit)
        {
            this.IdProduit = idProduit;
            this.NomProduit = nomProduit;
            this.DescriptionProduit = descriptionProduit;
            this.CaracteristiquesProduit = caracteristiquesProduit;
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


      

        public int MarqueId
        {
            get
            {
                return this.marqueId;
            }

            set
            {
                this.marqueId = value;
            }
        }

        [ForeignKey("MarqueId")]
        [InverseProperty("ProduitMarque")]
        public virtual Marque MarqueduProduit { get; set; } = null!;

        [InverseProperty("ProduitAvecCouleur")]
        public virtual ICollection<CouleurProduit> ColoriationDuProduit { get; set; }
    }
}
