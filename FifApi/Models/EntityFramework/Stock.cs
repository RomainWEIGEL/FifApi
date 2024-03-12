using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("stock")]
    public class Stock
    {
        private string tailleId;
        private int couleurProduitCId;
        private int couleurProduitPId;
        private int quantite;

        public Stock(string tailleId, int couleurProduitCId, int couleurProduitPId, int quantite)
        {
            this.tailleId = tailleId;
            this.couleurProduitCId = couleurProduitCId;
            this.couleurProduitPId = couleurProduitPId;
            this.quantite = quantite;
        }

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

        public int CouleurProduitCId
        {
            get
            {
                return couleurProduitCId;
            }

            set
            {
                couleurProduitCId = value;
            }
        }

        public int CouleurProduitPId
        {
            get
            {
                return this.couleurProduitPId;
            }

            set
            {
                this.couleurProduitPId = value;
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
