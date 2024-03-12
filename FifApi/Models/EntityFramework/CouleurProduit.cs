using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    public class CouleurProduit
    {
        private int produitId;
        private int couleurId;
        private double prix;
        private string codeBarre;

        public CouleurProduit(double prix, string codeBarre, int produitId, int couleurId)
        {
            this.prix = prix;
            this.codeBarre = codeBarre;
            this.ProduitId = produitId;
            this.CouleurId = couleurId;
        }

        
        [Column("prix", TypeName = "decimal(8,2)")]
        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        [Column("codebarre", TypeName = "varchar(48)")]
        public string CodeBarre
        {
            get { return codeBarre; }
            set { codeBarre = value; }
        }

        [Key]
        [Column("produitId", TypeName = "int")]
        public int ProduitId
        {
            get
            {
                return produitId;
            }

            set
            {
                produitId = value;
            }
        }

        [Key]
        [Column("couleurId", TypeName = "int")]
        public int CouleurId
        {
            get
            {
                return this.couleurId;
            }

            set
            {
                this.couleurId = value;
            }
        }

        [ForeignKey("ProduitId")]
        [InverseProperty("ColoriationDuProduit")]
        public virtual Produit ProduitAvecCouleur { get; set; } = null!;
        [ForeignKey("MatchId")]
        [InverseProperty("ColoriationDuProduit")]
        public virtual Couleur CouleurDuProduit { get; set; } = null!;


        [InverseProperty("ProduitEnTaille")]
        public virtual ICollection<Stock> StockDuProduit { get; set; }
    }
}
