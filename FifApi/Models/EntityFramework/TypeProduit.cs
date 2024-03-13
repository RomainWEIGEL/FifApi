using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("typeproduit")]
    public class TypeProduit
    {
        private int idType;
        private string nomType;
        private string descriptionType;
        private int sousTypeId;

        public TypeProduit(int idType, string nomType, string descriptionType, int sousTypeId)
        {
            this.idType = idType;
            this.nomType = nomType;
            this.descriptionType = descriptionType;
            this.SousTypeId = sousTypeId;
        }

        [Key]
        [Column("idtype", TypeName = "int")]
        public int IdType
        {
            get
            {
                return idType;
            }

            set
            {
                idType = value;
            }
        }

        [Column("nomtype", TypeName = "varchar(100)")]
        public string NomType
        {
            get
            {
                return nomType;
            }

            set
            {
                nomType = value;
            }
        }

        [Column("descriptiontype", TypeName = "varchar(150)")]
        public string DescriptionType
        {
            get
            {
                return descriptionType;
            }

            set
            {
                descriptionType = value;
            }
        }

        [Column("soustypeid", TypeName = "int")]
        public int SousTypeId
        {
            get
            {
                return this.sousTypeId;
            }

            set
            {
                this.sousTypeId = value;
            }
        }

        [InverseProperty("TypeEnSousType")]
        public virtual ICollection<TypeProduit> TypeDuProduit { get; set; }

        [InverseProperty("TypePourLeProduit")]
        public virtual ICollection<Produit> ProduitType { get; set; }

        [ForeignKey("SousTypeId")]
        [InverseProperty("TypeDuProduit")]
        public virtual TypeProduit TypeEnSousType { get; set; } = null!;
    }
}
