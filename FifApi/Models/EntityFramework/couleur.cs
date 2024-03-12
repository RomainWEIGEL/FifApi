using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("couleur")]
    public class Couleur
    {
        private int idCouleur;
        private string nomCouleur;

        public Couleur(int idCouleur, string nomCouleur)
        {
            this.idCouleur = idCouleur;
            this.nomCouleur = nomCouleur;
        }

        [Key]
        [Column("idcouleur", TypeName = "int")]
        public int IdCouleur
        {
            get { return idCouleur; }
            set { idCouleur = value; }
        }

        [Column("nomproduit", TypeName = "varchar(150)")]
        public string NomCouleur
        {
            get { return nomCouleur; }
            set { nomCouleur = value; }
        }

        [InverseProperty("CouleurDuProduit")]
        public virtual ICollection<CouleurProduit> ColoriationDuProduit { get; set; }

    }
}
