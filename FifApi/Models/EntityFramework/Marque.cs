using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("marque")]
    public class Marque
    {
        private int idMarque;
        private string nomMarque;

        public Marque(int idMarque, string nomMarque)
        {
            this.idMarque = idMarque;
            this.nomMarque = nomMarque;
        }

        [Key]
        [Column("idMarque", TypeName = "int")]
        public int IdMarque
        {
            get
            {
                return idMarque;
            }

            set
            {
                idMarque = value;
            }
        }

        [Column("nomMarque", TypeName = "varchar(200)")]
        public string NomMarque
        {
            get
            {
                return this.nomMarque;
            }

            set
            {
                this.nomMarque = value;
            }
        }

        [InverseProperty("MarqueduProduit")]
        public virtual ICollection<Produit> ProduitMarque { get; set; }
    }
}
