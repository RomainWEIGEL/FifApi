using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    public class CouleurProduit
    {
        private double prix;
        private string codeBarre;

        public CouleurProduit( double prix, string codeBarre )
        {
            this.prix = prix;
            this.codeBarre = codeBarre;
        }

        [Key]
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
    }
}
