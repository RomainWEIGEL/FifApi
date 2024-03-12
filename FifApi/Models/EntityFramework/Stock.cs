using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("stock")]
    public class Stock
    {
        private string tailleId;
        private int couleurProduitId;

        public Stock(string tailleId, int couleurProduitId)
        {
            this.TailleId = tailleId;
            this.CouleurProduitId = couleurProduitId;
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
    }
}
