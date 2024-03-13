using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("stock")]
    public class Stock
    {
        private string tailleId;
        private int couleurProduitId;
        private int quantite;

        public Stock(string tailleId, int couleurProduitId, int quantite)
        {
            this.TailleId = tailleId;
            this.CouleurProduitId = couleurProduitId;
            this.Quantite = quantite;
        }

        [Key]
        [Column("tailleid", TypeName = "char(6)")]
        public string TailleId
        {
            get
            {
                return tailleId;
            }

            set
            {
                tailleId = value;
            }
        }

        [Column("quantite", TypeName = "int")]
        public int Quantite
        {
            get
            {
                return this.quantite;
            }

            set
            {
                this.quantite = value;
            }
        }


        [Key]
        [Column("couleurproduitid", TypeName = "int")]
        public int CouleurProduitId
        {
            get
            {
                return this.couleurProduitId;
            }

            set
            {
                this.couleurProduitId = value;
            }
        }

        [ForeignKey("TailleId")]
        [InverseProperty("StockDuProduit")]
        public virtual Taille TailleDuProduit { get; set; } = null!;
        [ForeignKey("CouleurProduitId")]
        [InverseProperty("StockDuProduit")]
        public virtual CouleurProduit ProduitEnTaille { get; set; } = null!;

       
    }
}
