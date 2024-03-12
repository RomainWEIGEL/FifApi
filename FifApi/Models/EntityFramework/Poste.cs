using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("Poste")]
    public class Poste
    {
        private int idposte;
        private string nomPoste;
        private string descriptionPoste;

        public Poste(int idposte, string nomPoste, string descriptionPoste)
        {
            this.Idposte = idposte;
            this.NomPoste = nomPoste;
            this.DescriptionPoste = descriptionPoste;
        }

        [Key]
        [Column("idposte", TypeName = "int")]
        public int Idposte
        {
            get
            {
                return idposte;
            }

            set
            {
                idposte = value;
            }
        }

        [Column("nomPoste", TypeName = "Vachar(150)")]
        public string NomPoste
        {
            get
            {
                return nomPoste;
            }

            set
            {
                nomPoste = value;
            }
        }

        [Column("descriptionPoste", TypeName = "Vachar(300)")]
        public string DescriptionPoste
        {
            get
            {
                return this.descriptionPoste;
            }

            set
            {
                this.descriptionPoste = value;
            }
        }

        [InverseProperty("PostePourJoueur")]
        public virtual ICollection<Joueur> JoueurPoste { get; set; }
    }
}
